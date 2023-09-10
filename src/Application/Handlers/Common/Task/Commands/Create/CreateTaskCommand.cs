using Domain.Enums;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Common.Task.Commands.Create;
public record CreateTaskCommand(
    string Title, 
    string Description, 
    DateTimeOffset DueDate, 
    Status Status, 
    Priority Priority) : IRequest<Unit>;

public class CreateTaskValidator: AbstractValidator<CreateTaskCommand>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.DueDate)
            .GreaterThanOrEqualTo(DateTimeOffset.UtcNow)
            .WithMessage("Due Date can not be in the past");

        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("Title can not be null or empty");

        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage("Title can not be null or empty");
    }
}
