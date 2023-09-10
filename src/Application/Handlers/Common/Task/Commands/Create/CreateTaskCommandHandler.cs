using Domain.Context;
using MediatR;
using TaskEntity = Domain.Entities.Common.Task.Task;
using Domain.Entities.Common.Task;

namespace Application.Handlers.Common.Task.Commands.Create;
public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateTaskCommand request, 
        CancellationToken cancellationToken)
    {
        var task = new TaskEntity(
            new TaskId(Guid.NewGuid()),
            request.Title,
            request.Description,
            DueDate.Create(request.DueDate),
            request.Status,
            request.Priority
            );

        await _unitOfWork.Repository<TaskEntity>().AddAsync(task);

        await _unitOfWork.Complete(cancellationToken);

        return Unit.Value;
    }
}
