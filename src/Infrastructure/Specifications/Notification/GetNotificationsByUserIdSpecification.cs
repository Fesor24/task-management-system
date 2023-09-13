using NotificationEntity = Domain.Entities.Common.Notification.Notification;

namespace Infrastructure.Specifications.Notification;
public class GetNotificationsByUserIdSpecification : BaseSpecification<NotificationEntity>
{
    public GetNotificationsByUserIdSpecification(int userId) : base(x => x.UserId == userId)
    {
        
    }
}
