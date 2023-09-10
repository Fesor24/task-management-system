using Api.Definitions.Extensions;
using Shared.EndpointGroupings;
using Microsoft.OpenApi.Models;

namespace Api.Definitions;

public class SwaggerDefinition : IDefinition
{
    public void DefinePipelineAndRoutesConfiguration(WebApplication app, IConfiguration configuration)
    {
        app.UseSwagger();

        app.UseSwaggerUI(opt =>
        {
            opt.SwaggerEndpoint($"/swagger/{EndpointGroupNames.MAIN}/swagger.json", EndpointGroupNames.MAIN + " endpoints");
            opt.SwaggerEndpoint($"/swagger/{EndpointGroupNames.ACCOUNT}/swagger.json", EndpointGroupNames.ACCOUNT + " endpoints");
        });
    }

    public void DefineServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc(EndpointGroupNames.ACCOUNT, new OpenApiInfo { Title = EndpointGroupNames.ACCOUNT + " endpoints" });
            opt.SwaggerDoc(EndpointGroupNames.MAIN, new OpenApiInfo { Title = EndpointGroupNames.MAIN + " endpoints" });
        });
    }
}
