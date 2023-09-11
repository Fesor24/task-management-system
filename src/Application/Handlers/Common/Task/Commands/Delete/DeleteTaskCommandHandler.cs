using Domain.Context;
using Infrastructure.Specifications.Task;
using MediatR;
using Shared.Exceptions;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Application.Handlers.Common.Task.Commands.Delete;
public sealed class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var taskSpec = new GetTaskByIdSpecification(request.TaskId);

        var task = await _unitOfWork.Repository<TaskEntity>().GetAsync(taskSpec);

        if (task is null)
            throw new ApiNotFoundException($"Task with TaskId: {request.TaskId} not found");

        _unitOfWork.Repository<TaskEntity>().Delete(task);

        await _unitOfWork.Complete(cancellationToken);

        return Unit.Value;
    }
}
