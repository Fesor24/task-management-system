using Domain.Context;
using Domain.Entities.Common.Task;
using Domain.Enums;
using Domain.Services.Notification;
using Domain.Services.Users;
using MediatR;
using Shared.Exceptions;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Application.Handlers.Common.Task.Commands.Create;
public sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    private readonly INotificationService _notificationService;

    public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext,
        INotificationService notificationService)
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _notificationService = notificationService;
    }

    public async Task<int> Handle(CreateTaskCommand request, 
        CancellationToken cancellationToken)
    {
        if (!Enum.IsDefined(typeof(Priority), request.Priority))
            throw new ApiBadRequestException("Invalid value passed to priority");

        if (!Enum.IsDefined(typeof(Domain.Enums.TaskStatus), request.Status))
            throw new ApiBadRequestException("Invalid value passed to task status");

        var task = new TaskEntity(
            new Body(request.Title, request.Description),
            DueDate.Create(request.DueDate),
            request.Status,
            request.Priority,
            request.ProjectId == default(int) ? null : request.ProjectId,
            _userContext.UserId
            );

        await _unitOfWork.Repository<TaskEntity>().AddAsync(task);

        var result = await _unitOfWork.Complete();

        if (result)
            await _notificationService.TaskAssignment(task.Body.Title, task.Status.ToString(), task.TaskId);

        return task.TaskId;
    }
}
