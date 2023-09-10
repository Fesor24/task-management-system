using Application.Endpoints;
using Application.Mediator;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class CoreApplicationExtensions
{
    public static Type AddCoreApplication(this IServiceCollection services)
    {
        AddMediator(services);
        return typeof(CoreApplicationExtensions);
    }

    public static WebApplication AddCoreApplication(this WebApplication app)
    {
        CommonEndpoints.AddEndpoints(app);

        return app;
    }

    private static void AddMediator(IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MediatorValidationPipelineBehavior<,>));
    }
}
