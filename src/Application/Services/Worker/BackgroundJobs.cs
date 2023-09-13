using Domain.Services.Notification;
using Hangfire;

namespace Application.Services.Worker;
public class BackgroundJobs
{
    private readonly IRecurringJobManager _recurringJobManager;

    public BackgroundJobs(IRecurringJobManager recurringJobManager)
    {
        _recurringJobManager = recurringJobManager;
    }

    // Task will be executed every 10 minutes
    // Reminder notifications will only be sent once in respect of a task
    public void DueTaskUserReminderNotification()
    {
        _recurringJobManager.AddOrUpdate<INotificationService>(JobIdentifier.TASKREMINDER, (method) => method.SetTaskReminder(), 
            "*/10 * * * *");
    }
}
