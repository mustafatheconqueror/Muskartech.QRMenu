using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Muskartech.QRMenu.Infrastructure.Settings;

namespace Muskartech.QRMenu.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly AuthenticationSettings _authenticationSettings;
    
    public static readonly Lazy<List<string>> AllAvailableClaims = new Lazy<List<string>>(() =>
    {
        var allAvailableClaims = Assembly.Load("Muskartech.QRMenu.API").GetTypes()
            .Where(type => typeof(ControllerBase).IsAssignableFrom(type)) //filter controllers
            .SelectMany(type => type.GetMethods())
            .Where(method => method.IsPublic && method.IsDefined(typeof(AuthorizeAttribute)))
            .Select(p => p.GetCustomAttribute<AuthorizeAttribute>().Policy)
            .ToList();

        return allAvailableClaims;
    });

    public AuthenticationService(IOptions<AuthenticationSettings> authenticationSettings)
    {
        _authenticationSettings = authenticationSettings.Value;
    }


    
    public string GenerateToken(AuthenticationUser authenticationUser)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, authenticationUser.UserName),
            new Claim(JwtRegisteredClaimNames.NameId, authenticationUser.UserName)
        };

        var signingCredentials =
            new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.IssuerSigningKey)),
                SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(_authenticationSettings.Expires),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public (AuthenticationUser User, bool Succeed) Login(string userName, string password)
    {
        var user = _authenticationSettings.Users.FirstOrDefault(p =>
            p.UserName == userName && p.Password == password);

        return (user, user != null);
    }

    public bool ValidateToken(TokenValidatedContext ctx)
    {
        var authenticatedUser =
            _authenticationSettings.Users.FirstOrDefault(p => p.UserName == ctx.Principal.Identity.Name);

        if (authenticatedUser == null)
        {
            throw new Exception("User not found");
        }

        var authenticatedUserClaims = new List<string> {AuthenticationConstant.TokenCheckClaim};
            
        if (authenticatedUser.Claims.Contains(AuthenticationConstant.SuperAdminClaim))
        {
            authenticatedUserClaims.AddRange(AllAvailableClaims.Value);
        }
        else
        {
            authenticatedUserClaims.AddRange(authenticatedUser.Claims);
        }
            
        var claimsIdentity = new ClaimsIdentity(authenticatedUserClaims.Select(p => new Claim(p, bool.TrueString)), AuthenticationConstant.AuthenticationTypeFederation);
            
        claimsIdentity.AddClaims(ctx.Principal.Claims);
        ctx.Principal = new ClaimsPrincipal(claimsIdentity);

        return true;
    }

}