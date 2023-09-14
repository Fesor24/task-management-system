using MediatR;

namespace Application.Handlers.Common.Notifications.Command.UpdateNotificationStatus;
public record UpdateNotificationStatusCommand(int NotificationId) : IRequest<Unit>;
