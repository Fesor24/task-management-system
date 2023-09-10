namespace Api.Definitions.Extensions;

public interface IDefinition
{
    void DefineServices(IServiceCollection services, IConfiguration configuration);
    void DefinePipelineAndRoutesConfiguration(WebApplication app,  IConfiguration configuration);
}
