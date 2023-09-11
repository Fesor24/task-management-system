using Api.Definitions.Extensions;
using Api.Helpers;
using Domain.Services.Users;

namespace Api.Definitions;

public class UserContextDefinition : IDefinition
{
    public void DefinePipelineAndRoutesConfiguration(WebApplication app, IConfiguration configuration)
    {
        
    }

    public void DefineServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IUserContext, UserContext>();
    }
}
