using Domain.Context;
using Domain.Entities.Users;
using Domain.Services.Users;
using MediatR;

namespace Application.Handlers.Account.Command.Register;
public sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISecurityService _securityService;

    public RegisterCommandHandler(IUnitOfWork unitOfWork, ISecurityService securityService)
    {
        _unitOfWork = unitOfWork;
        _securityService = securityService;
    }

    public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User(
            new UserInfo(request.Name, request.Email),
            _securityService.HashPassword(request.Password)
            );

        await _unitOfWork.Repository<User>().AddAsync(user);

        await _unitOfWork.Complete(cancellationToken);

        return new RegisterResponse(_securityService.GenerateJwts(user));
    }
}
