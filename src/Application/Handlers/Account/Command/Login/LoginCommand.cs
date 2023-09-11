using MediatR;

namespace Application.Handlers.Account.Command.Login;
public record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;
