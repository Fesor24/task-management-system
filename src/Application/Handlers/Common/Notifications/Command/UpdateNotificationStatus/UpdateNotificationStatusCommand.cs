using Domain.Enums;
using MediatR;

namespace Application.Handlers.Common.Notifications.Command.UpdateNotificationStatus;
public record UpdateNotificationStatusCommand(int NotificationId, NotificationStatus Status) : 
    IRequest<Unit>;
