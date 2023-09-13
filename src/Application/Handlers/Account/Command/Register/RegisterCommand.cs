using FluentValidation;
using MediatR;

namespace Application.Handlers.Account.Command.Register;
public record RegisterCommand(string Name, string Email, string Password) : IRequest<RegisterResponse>;

public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name can not be null or empty");

        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage("Email can not be null or empty");

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Invalid email address");

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage("Password can not be null or empty");
    }
}
