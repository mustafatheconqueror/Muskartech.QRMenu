namespace Muskartech.QRMenu.Infrastructure.Settings;

public class AuthenticationSettings
{
    public string IssuerSigningKey { get; set; }
    public int Expires { get; set; }
    public List<AuthenticationUser> Users { get; set; }
}

public class AuthenticationUser
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public List<string> Claims { get; set; }
}