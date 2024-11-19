namespace Muskartech.QRMenu.Infrastructure.Authentication;

public class AuthenticationConstant
{
    public const string IdentityNameHeader = "Identity-Name";
    public const string IdentityTypeHeader = "Identity-Type";

    public const string AuthorizationHeader = "Authorization";
    public const string BearerScheme = "Bearer";
    public const string SuperAdminClaim = "SuperAdmin";
    public const string TokenCheckClaim = "TokenCheck";
    public const string AuthenticationTypeFederation = "AuthenticationTypes.Federation";
    public const string NoTokenHeader = "NO_TOKEN";
}