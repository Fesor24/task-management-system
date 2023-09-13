using Domain.Context;
using Domain.Services.Users;
using MediatR;
using ProjectEntity = Domain.Entities.Common.Project.Project;

namespace Application.Handlers.Common.Project.Commands.Create;
public sealed class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new ProjectEntity(
            request.Name,
            request.Description,
            _userContext.UserId);

        await _unitOfWork.Repository<ProjectEntity>().AddAsync(project);

        await _unitOfWork.Complete(cancellationToken);

        return project.ProjectId;
    }
}
