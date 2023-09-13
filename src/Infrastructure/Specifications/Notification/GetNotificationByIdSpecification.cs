using NotificationEntity = Domain.Entities.Common.Notification.Notification;

namespace Infrastructure.Specifications.Notification;
public class GetNotificationByIdSpecification : BaseSpecification<NotificationEntity>
{
    public GetNotificationByIdSpecification(int notificationId, int userId) : base(x => x.NotificationId == notificationId &&
        x.UserId == userId)
    {
        
    }
}
