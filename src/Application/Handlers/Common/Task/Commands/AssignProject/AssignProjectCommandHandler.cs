using Domain.Context;
using Infrastructure.Specifications.Task;
using MediatR;
using Shared.Exceptions;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Application.Handlers.Common.Task.Commands.AssignProject;
public sealed class AssignProjectCommandHandler : IRequestHandler<AssignProjectCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public AssignProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AssignProjectCommand request, CancellationToken cancellationToken)
    {
        var taskSpec = new GetTaskByIdSpecification(request.TaskId);

        var task = await _unitOfWork.Repository<TaskEntity>().GetAsync(taskSpec);

        if (task is null)
            throw new ApiNotFoundException($"Task with Id: {request.TaskId} not found");

        int? projectId = request.ProjectId == default(int) ? null : request.ProjectId;

        task.AssignProject(projectId);

        _unitOfWork.Repository<TaskEntity>().Update(task);

        await _unitOfWork.Complete(cancellationToken);

        return Unit.Value;
    }
}
