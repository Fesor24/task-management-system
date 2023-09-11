using Domain.Context;
using Infrastructure.Specifications.Task;
using MediatR;
using Shared.Exceptions;
using TaskEntity = Domain.Entities.Common.Task.Task;
using Domain.Entities.Common.Task;

namespace Application.Handlers.Common.Task.Commands.Update;
public sealed class UpdateTaskCommandHadler : IRequestHandler<UpdateTaskCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTaskCommandHadler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskSpec = new GetTaskByIdSpecification(request.TaskId);

        var task = await _unitOfWork.Repository<TaskEntity>().GetAsync(taskSpec);

        if (task is null)
            throw new ApiNotFoundException($"Task with Id: {request.TaskId} not found");

        task.Update(new Body(request.Title, request.Description), DueDate.Create(request.DueDate), 
            request.Status, request.Priority);

        _unitOfWork.Repository<TaskEntity>().Update(task);

        return Unit.Value;
    }
}
