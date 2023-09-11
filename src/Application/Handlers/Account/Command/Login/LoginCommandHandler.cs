using Domain.Context;
using Domain.Entities.Users;
using Domain.Services.Users;
using Infrastructure.Specifications.User;
using MediatR;
using Shared.Exceptions;

namespace Application.Handlers.Account.Command.Login;
public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISecurityService _securityService;

    public LoginCommandHandler(IUnitOfWork unitOfWork, ISecurityService securityService)
    {
        _unitOfWork = unitOfWork;
        _securityService = securityService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var userSpec = new GetUserByEmailSpecification(request.Email);

        var user = await _unitOfWork.Repository<User>().GetAsync(userSpec);

        if (user is null)
            throw new ApiUnauthorizedException("Unauthorized");

        var hashedPassword = _securityService.HashPassword(request.Password);

        if(user.Password != hashedPassword)
            throw new ApiUnauthorizedException("Unauthorized");

        return new LoginResponse(_securityService.GenerateJwts(user));
    }
}
