namespace Shared.AppSettings;
public class JwtBearerSettings
{
    public const string ConfigurationName = "JwtBearerSettings";

    public string Scheme { get; set; }
    public string Issuer { get; set; }
    public string Key { get; set; }
    public string AuthorizationHeaderName { get; set; }
    public int SessionTimeout { get; set; }
}
