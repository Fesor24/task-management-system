namespace Domain.Services.Notification;
public interface INotificationService
{
    Task SetTaskReminder();
    Task TaskAssignment(string taskName, string taskStatus, int taskId);
    Task TaskCompleted(string taskName, int taskId);
}
