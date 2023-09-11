using Api.Definitions.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shared.AppSettings;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Definitions;

public class AuthenticationDefinition : IDefinition
{
    public void DefinePipelineAndRoutesConfiguration(WebApplication app, IConfiguration configuration)
    {
        app.UseAuthentication();
    }

    public void DefineServices(IServiceCollection services, IConfiguration configuration)
    {
        var jwtBearerSettings = new JwtBearerSettings();

        configuration.Bind(JwtBearerSettings.ConfigurationName, jwtBearerSettings);

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtBearerSettings.Issuer,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidAudience = jwtBearerSettings.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtBearerSettings.Key))
                };
            });
    }
}
