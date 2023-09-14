using Domain.Context;
using Domain.Entities.Common.Notification;
using Domain.Enums;
using Domain.Services.Users;
using Infrastructure.Specifications.Notification;
using MediatR;
using Shared.Exceptions;

namespace Application.Handlers.Common.Notifications.Command.UpdateNotificationStatus;
public class UpdateNotificationStatusCommandHandler : IRequestHandler<UpdateNotificationStatusCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;

    public UpdateNotificationStatusCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(UpdateNotificationStatusCommand request, CancellationToken cancellationToken)
    {
        var notificationSpec = new GetNotificationByIdSpecification(request.NotificationId, _userContext.UserId);

        var notification = await _unitOfWork.Repository<Notification>().GetAsync(notificationSpec);

        if (notification is null)
            throw new ApiNotFoundException($"Notification with id: {request.NotificationId} not found");

        if (!Enum.IsDefined(typeof(NotificationStatus), request.Status))
            throw new ApiBadRequestException("Invalid notification Status");

        notification.UpdateStatus(request.Status);

        _unitOfWork.Repository<Notification>().Update(notification);

        await _unitOfWork.Complete();

        return Unit.Value;
    }
}
