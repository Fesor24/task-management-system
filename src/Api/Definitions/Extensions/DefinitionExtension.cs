namespace Api.Definitions.Extensions;

public static class DefinitionExtension
{
    public static void AddServicesToContainer(this IServiceCollection services, IConfiguration config, 
        params Type[] scanMarkers)
    {
        var definitions = new List<IDefinition>();

        foreach (var marker in scanMarkers)
        {
            definitions.AddRange(marker.Assembly.ExportedTypes
                .Where(x => typeof(IDefinition).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface)
                .Select(Activator.CreateInstance).Cast<IDefinition>()
                );
        }

        foreach(var definition in definitions)
        {
            definition.DefineServices(services, config);
        }

        services.AddSingleton(definitions as IReadOnlyCollection<IDefinition>);
    }

    public static void ConfigureHttpPipelineAndRoutes(this WebApplication app, IConfiguration config)
    {
        var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IDefinition>>().AsEnumerable();

        var swaggerDefinition = definitions.Where(d => d.GetType() == typeof(SwaggerDefinition)).SingleOrDefault();

        if(swaggerDefinition is not null)
        {
            swaggerDefinition.DefinePipelineAndRoutesConfiguration(app, config);
        }

        foreach(var definition in definitions)
        {
            definition.DefinePipelineAndRoutesConfiguration(app, config);
        }
    }
}
