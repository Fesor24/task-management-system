using MediatR;

namespace Application.Handlers.Common.Notifications.Command.Delete;
public class DeleteNotificationCommand : IRequest<Unit>
{
    public int NotificationId { get; set; }
}
