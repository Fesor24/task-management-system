using Domain.Context;
using Infrastructure.Specifications.Task;
using MediatR;
using Shared.Exceptions;
using TaskEntity = Domain.Entities.Common.Task.Task;
using Domain.Entities.Common.Task;
using Domain.Services.Notification;
using Domain.Services.Users;

namespace Application.Handlers.Common.Task.Commands.Update;
public sealed class UpdateTaskCommandHadler : IRequestHandler<UpdateTaskCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationService _notificationService;
    private readonly IUserContext _userContext;

    public UpdateTaskCommandHadler(IUnitOfWork unitOfWork, INotificationService notificationService,
        IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _notificationService = notificationService;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskSpec = new GetTaskByIdSpecification(request.TaskId, _userContext.UserId);

        var task = await _unitOfWork.Repository<TaskEntity>().GetAsync(taskSpec);

        if (task is null)
            throw new ApiNotFoundException($"Task with Id: {request.TaskId} not found");

        task.Update(new Body(request.Title, request.Description), DueDate.Create(request.DueDate), 
            request.Status, request.Priority);

        _unitOfWork.Repository<TaskEntity>().Update(task);

        var result = await _unitOfWork.Complete();

        if (result && request.Status == Domain.Enums.TaskStatus.Completed)
            await _notificationService.TaskCompleted(task.Body.Title, task.TaskId);

        return Unit.Value;
    }
}
