using FluentValidation;
using MediatR;

namespace Application.Handlers.Common.Project.Commands.Create;
public record CreateProjectCommand(
    string Name,
    string Description
    ) : IRequest<int>;

public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Name can not be null or empty");

        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage("Description can not be null or empty");
    }
}
