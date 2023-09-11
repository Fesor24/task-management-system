using Api.Definitions.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Api.Definitions;

public class AuthorizationDefinition : IDefinition
{
    public void DefinePipelineAndRoutesConfiguration(WebApplication app, IConfiguration configuration)
    {
        app.UseHttpsRedirection();
        app.UseCors("CorsPolicy");
        app.UseAuthorization();
    }

    public void DefineServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthorization(opt =>
        {
            opt.FallbackPolicy = new AuthorizationPolicyBuilder()
            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser()
            .Build();
        });

        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            });
        });
    }
}
