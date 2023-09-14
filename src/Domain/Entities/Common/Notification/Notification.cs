using Domain.Enums;

namespace Domain.Entities.Common.Notification;
public class Notification : AuditableEntity
{
    public Notification()
    {
        
    }

    public Notification(int? userId, string message, NotificationType notificationType, int taskId)
    {
        UserId = userId;
        Message = message;
        NotificationType = notificationType;
        NotificationStatus = NotificationStatus.Unread;
        TaskId = taskId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public int NotificationId { get; private set; }
    public string Message { get; private set; }
    public int? UserId { get; private set; }
    public int TaskId { get; private set; }
    public NotificationStatus NotificationStatus { get; private set; }
    public NotificationType NotificationType { get; private set; }

    public void UpdateStatus(NotificationStatus status) =>
        NotificationStatus = status;
}
