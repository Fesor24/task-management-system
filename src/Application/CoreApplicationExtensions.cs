using Application.Endpoints;
using Application.Mediator;
using Application.Services.Notification;
using Application.Services.Users;
using Domain.Services.Notification;
using Domain.Services.Users;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;

namespace Application;
public static class CoreApplicationExtensions
{
    public static Type AddCoreApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddMediator(services);
        AddServices(services);
        AddHangfire(services, configuration);
        return typeof(CoreApplicationExtensions);
    }

    public static WebApplication AddCoreApplication(this WebApplication app)
    {
        CommonEndpoints.AddEndpoints(app);
        AccountEndpoints.AddEndpoints(app);

        app.UseHangfireDashboard();

        return app;
    }

    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<ISecurityService, SecurityService>();
        services.AddScoped<INotificationService, NotificationService>();
    }

    private static void AddMediator(IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MediatorValidationPipelineBehavior<,>));
    }

    private static void AddHangfire(IServiceCollection services, IConfiguration config)
    {
        services.AddHangfire(opt =>
        {
            opt.UsePostgreSqlStorage(config.GetConnectionString("DefaultConnection"));
        });

        services.AddHangfireServer();
    }
}
