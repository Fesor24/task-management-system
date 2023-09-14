using Domain.Enums;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Common.Task.Commands.Update;
public record UpdateTaskCommand(int TaskId,
    string Title, 
    string Description,
    Domain.Enums.TaskStatus? Status,
    Priority? Priority,
    DateTime DueDate) : 
    IRequest<Unit>;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(x => x.DueDate)
            .GreaterThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Due date can not be in the past");
    }
}

