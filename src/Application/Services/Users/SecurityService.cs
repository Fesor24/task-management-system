using Domain.Entities.Users;
using Domain.Services.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.AppSettings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services.Users;
public class SecurityService : ISecurityService
{
    private readonly JwtBearerSettings _jwtBearerSettings = new();

    public SecurityService(IConfiguration configuration)
    {
        configuration.GetSection(JwtBearerSettings.ConfigurationName).Bind(_jwtBearerSettings);
    }

    public string GenerateJwts(User user)
    {
        int sessionTimeout = _jwtBearerSettings.SessionTimeout;
        var expires = DateTime.UtcNow.AddMinutes(sessionTimeout);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtBearerSettings.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.UserInfo.Email),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };

        var token = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: credentials,
            issuer: _jwtBearerSettings.Issuer,
            audience: _jwtBearerSettings.Issuer
            );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }

    public string HashPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            return string.Empty;
        }

        byte[] passwordByte = Encoding.UTF8.GetBytes(password);

        byte[] data = SHA256.Create().ComputeHash(passwordByte);

        return Convert.ToBase64String(data);
    }
}
