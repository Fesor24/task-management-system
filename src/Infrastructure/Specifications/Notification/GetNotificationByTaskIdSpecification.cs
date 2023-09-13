using NotificationEntity =  Domain.Entities.Common.Notification.Notification;

namespace Infrastructure.Specifications.Notification;
public class GetNotificationByTaskIdSpecification : BaseSpecification<NotificationEntity>
{
    public GetNotificationByTaskIdSpecification(int taskId) : base(x => x.TaskId == taskId && 
        x.NotificationType == Domain.Enums.NotificationType.TaskReminder)
    {
        
    }
}
