using System.Text;
using System.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Muskartech.QRMenu.Infrastructure.Loggers;
using Muskartech.QRMenu.Infrastructure.Settings;

namespace Muskartech.QRMenu.Infrastructure.Authentication;

public static class AuthenticationExtensions
{
    public static Identity ToIdentity(this HttpContext context)
    {
        var identityNameHeader = context.Request.Headers.ContainsKey(AuthenticationConstant.IdentityNameHeader)
            ? context.Request.Headers[AuthenticationConstant.IdentityNameHeader].FirstOrDefault()
            : null;
        var identityTypeHeader = context.Request.Headers.ContainsKey(AuthenticationConstant.IdentityTypeHeader)
            ? context.Request.Headers[AuthenticationConstant.IdentityTypeHeader].FirstOrDefault()
            : null;

        if (string.IsNullOrEmpty(identityNameHeader) && string.IsNullOrEmpty(identityTypeHeader))
        {
            return null;
        }

        identityNameHeader = HttpUtility.UrlDecode(identityNameHeader);

        return new Identity
        {
            Name = identityNameHeader,
            Type = identityTypeHeader
        };
    }

    public static IServiceCollection AddAuthenticationAuthorization(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        services.Configure<AuthenticationSettings>(configuration.GetSection(nameof(AuthenticationSettings)));

        var authenticationSettings =
            configuration.GetSection(nameof(AuthenticationSettings)).Get<AuthenticationSettings>();

        Action<JwtBearerOptions> authenticationConfigureOptions = options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = true,
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.IssuerSigningKey)),
                ClockSkew = TimeSpan.Zero
            };

            options.Events = new JwtBearerEvents
            {
                OnTokenValidated = ctx =>
                {
                    var authenticationService =
                        ctx.HttpContext.RequestServices.GetService<IAuthenticationService>();

                    authenticationService.ValidateToken(ctx);

                    return Task.CompletedTask;
                },
                OnAuthenticationFailed = ctx =>
                {
                    if (!(ctx.Exception is SecurityTokenExpiredException))
                    {
                        var logger = ctx.HttpContext.RequestServices.GetService<IConsoleLogger>();

                        logger.LogError("OnAuthenticationFailed", ctx.Exception);
                    }

                    ctx.Fail(ctx.Exception);

                    return Task.CompletedTask;
                },
                OnChallenge = ctx => { return Task.CompletedTask; }
            };
        };

        services.AddSingleton<IPostConfigureOptions<JwtBearerOptions>, JwtBearerPostConfigureOptions>();
        var authenticationBuilder = services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
        );


        authenticationBuilder.AddJwtBearer(authenticationConfigureOptions);


        services
            .AddAuthorization(options =>
            {
                foreach (var claim in AuthenticationService.AllAvailableClaims.Value)
                {
                    options.AddPolicy(claim, policy => policy.RequireClaim(claim));
                }
            });

        return services;
    }
}