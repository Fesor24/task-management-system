using Application.Services.Worker;
using Hangfire;

namespace Api.Helpers;

public class JobsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IRecurringJobManager _recurringJobManager;

    public JobsMiddleware(RequestDelegate next, IRecurringJobManager recurringJobManager)
    {
        _next = next;
        _recurringJobManager = recurringJobManager;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            BackgroundJobs jobs = new(_recurringJobManager);

            jobs.DueTaskUserReminderNotification();

            await _next(context);
        }

        catch (Exception ex)
        {
            throw;
        }
      
    }
}
