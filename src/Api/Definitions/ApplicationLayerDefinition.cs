using Api.Definitions.Extensions;
using Application;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace Api.Definitions;

public class ApplicationLayerDefinition : IDefinition
{
    public void DefinePipelineAndRoutesConfiguration(WebApplication app, IConfiguration configuration)
    {
        app.AddCoreApplication();
    }

    public void DefineServices(IServiceCollection services, IConfiguration configuration)
    {
        IEnumerable<Assembly> domainAssemblies = new List<Type>()
        {
            services.AddCoreApplication(configuration)
        }.Select(t => t.Assembly);

        services
            .AddMediatR(domainAssemblies.ToArray())
            .AddValidatorsFromAssemblies(domainAssemblies)
            .AddAutoMapper(domainAssemblies);
    }
}
