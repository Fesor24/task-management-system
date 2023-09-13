using AutoMapper;
using Domain.Context;
using Domain.Entities.Common.Notification;
using Domain.Services.Users;
using Infrastructure.Specifications.Notification;
using MediatR;

namespace Application.Handlers.Common.Notifications.Query.GetNotificationsByUserId;
public class GetNotificationsByUserIdRequestHandler : IRequestHandler<GetNotificationsByUserIdRequest,
    IReadOnlyList<GetNotificationResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetNotificationsByUserIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<IReadOnlyList<GetNotificationResponse>> Handle(GetNotificationsByUserIdRequest request, 
        CancellationToken cancellationToken)
    {
        var notificationSpec = new GetNotificationsByUserIdSpecification(_userContext.UserId);

        var notifications = await _unitOfWork.Repository<Notification>().GetAllAsync(notificationSpec);

        return _mapper.Map<IReadOnlyList<GetNotificationResponse>>(notifications);
    }
}
