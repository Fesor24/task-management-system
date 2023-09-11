using Domain.Enums;
using MediatR;

namespace Application.Handlers.Common.Task.Commands.Update;
public record UpdateTaskCommand(int TaskId,
    string Title, 
    string Description,
    Status Status,
    Priority Priority,
    DateTime DueDate) : 
    IRequest<Unit>;
