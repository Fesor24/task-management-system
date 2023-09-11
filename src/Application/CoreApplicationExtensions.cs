using Application.Endpoints;
using Application.Mediator;
using Application.Services.Users;
using Domain.Services.Users;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class CoreApplicationExtensions
{
    public static Type AddCoreApplication(this IServiceCollection services)
    {
        AddMediator(services);
        AddServices(services);
        return typeof(CoreApplicationExtensions);
    }

    public static WebApplication AddCoreApplication(this WebApplication app)
    {
        CommonEndpoints.AddEndpoints(app);
        AccountEndpoints.AddEndpoints(app);

        return app;
    }

    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<ISecurityService, SecurityService>();
    }

    private static void AddMediator(IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MediatorValidationPipelineBehavior<,>));
    }
}
