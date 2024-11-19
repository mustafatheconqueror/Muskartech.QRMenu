using Microsoft.AspNetCore.Authentication.JwtBearer;
using Muskartech.QRMenu.Infrastructure.Settings;

namespace Muskartech.QRMenu.Infrastructure.Authentication;

public interface IAuthenticationService
{
    string GenerateToken(AuthenticationUser authenticationUser);
    (AuthenticationUser User, bool Succeed) Login(string userName, string password);
    bool ValidateToken(TokenValidatedContext ctx);
}