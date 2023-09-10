using Api.Definitions.Extensions;

namespace Api.Definitions;

public class AuthorizationDefinition : IDefinition
{
    public void DefinePipelineAndRoutesConfiguration(WebApplication app, IConfiguration configuration)
    {
        app.UseHttpsRedirection();
        app.UseCors("CorsPolicy");
        //app.UseAuthorization();
    }

    public void DefineServices(IServiceCollection services, IConfiguration configuration)
    {
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
