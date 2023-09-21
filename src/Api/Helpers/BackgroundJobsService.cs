using Application.Services.Worker;
using Hangfire;

namespace Api.Helpers;

public class BackgroundJobsService : IHostedService
{
    private readonly IRecurringJobManager _recurringJobManager;

    public BackgroundJobsService(IRecurringJobManager recurringJobManager)
    {
        _recurringJobManager = recurringJobManager;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        BackgroundJobs jobs = new(_recurringJobManager);

        jobs.DueTaskUserReminderNotification();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
