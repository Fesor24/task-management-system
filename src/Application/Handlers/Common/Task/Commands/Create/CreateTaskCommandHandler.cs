using Domain.Context;
using Domain.Entities.Common.Task;
using Domain.Services.Users;
using MediatR;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Application.Handlers.Common.Task.Commands.Create;
public sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;

    public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<int> Handle(CreateTaskCommand request, 
        CancellationToken cancellationToken)
    {
        var task = new TaskEntity(
            new Body(request.Title, request.Description),
            DueDate.Create(request.DueDate),
            request.Status,
            request.Priority,
            request.ProjectId == default(int) ? null : request.ProjectId,
            _userContext.UserId
            );

        await _unitOfWork.Repository<TaskEntity>().AddAsync(task);

        await _unitOfWork.Complete(cancellationToken);

        return task.TaskId;
    }
}
