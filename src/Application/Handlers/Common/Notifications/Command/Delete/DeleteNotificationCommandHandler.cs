using Domain.Context;
using Domain.Entities.Common.Notification;
using Domain.Services.Users;
using Infrastructure.Specifications.Notification;
using MediatR;
using Shared.Exceptions;

namespace Application.Handlers.Common.Notifications.Command.Delete;
public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;

    public DeleteNotificationCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {
        var notificationSpec = new GetNotificationByIdSpecification(request.NotificationId, _userContext.UserId);

        var notification = await _unitOfWork.Repository<Notification>().GetAsync(notificationSpec);

        if (notification is null)
            throw new ApiNotFoundException($"Notification with Id: {request.NotificationId} not found");

        _unitOfWork.Repository<Notification>().Delete(notification);

        await _unitOfWork.Complete();

        return Unit.Value;
    }
}
