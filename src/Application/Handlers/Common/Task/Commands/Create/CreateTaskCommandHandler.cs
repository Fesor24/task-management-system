using Domain.Context;
using Domain.Entities.Common.Task;
using MediatR;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Application.Handlers.Common.Task.Commands.Create;
public sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTaskCommand request, 
        CancellationToken cancellationToken)
    {
        var task = new TaskEntity(
            new Body(request.Title, request.Description),
            DueDate.Create(request.DueDate),
            request.Status,
            request.Priority,
            request.ProjectId == default(int) ? null : request.ProjectId
            );

        await _unitOfWork.Repository<TaskEntity>().AddAsync(task);

        await _unitOfWork.Complete(cancellationToken);

        return task.TaskId;
    }
}
