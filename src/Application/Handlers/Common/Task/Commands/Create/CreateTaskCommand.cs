using Domain.Enums;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Common.Task.Commands.Create;
public record CreateTaskCommand(
    string Title, 
    string Description, 
    DateTime DueDate, 
    Status Status,
    Priority Priority,
    int? ProjectId) : IRequest<int>;

public class CreateTaskValidator: AbstractValidator<CreateTaskCommand>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.DueDate)
            .GreaterThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Due Date can not be in the past");

        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("Title can not be null or empty");

        RuleFor(x => x.Title)
            .MaximumLength(200)
            .WithMessage("Title has a maximum length of 200 characters");

        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage("Description can not be null or empty");

        RuleFor(x => x.Description)
            .MaximumLength(700)
            .WithMessage("Description has a maximum length of 700 characters");
    }
}
