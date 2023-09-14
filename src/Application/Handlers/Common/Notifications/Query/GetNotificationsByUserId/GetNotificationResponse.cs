namespace Application.Handlers.Common.Notifications.Query.GetNotificationsByUserId;
public class GetNotificationResponse
{
    public int NotificationId { get; set; }
    public string NotificationStatus { get; set; }
    public string Message { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
