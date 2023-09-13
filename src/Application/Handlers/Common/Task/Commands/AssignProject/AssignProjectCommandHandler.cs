using Domain.Context;
using Domain.Services.Users;
using Infrastructure.Specifications.Task;
using MediatR;
using Shared.Exceptions;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Application.Handlers.Common.Task.Commands.AssignProject;
public sealed class AssignProjectCommandHandler : IRequestHandler<AssignProjectCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;

    public AssignProjectCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(AssignProjectCommand request, CancellationToken cancellationToken)
    {
        var taskSpec = new GetTaskByIdSpecification(request.TaskId, _userContext.UserId);

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
