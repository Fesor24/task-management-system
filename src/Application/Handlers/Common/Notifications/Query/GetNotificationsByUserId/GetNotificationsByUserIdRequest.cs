using MediatR;

namespace Application.Handlers.Common.Notifications.Query.GetNotificationsByUserId;
public record GetNotificationsByUserIdRequest : IRequest<IReadOnlyList<GetNotificationResponse>>;
