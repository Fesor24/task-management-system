using Domain.Context;
using ProjectEntity =  Domain.Entities.Common.Project.Project;
using Infrastructure.Specifications.Project;
using MediatR;
using Shared.Exceptions;
using Domain.Services.Users;

namespace Application.Handlers.Common.Project.Commands.Delete;
public sealed class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;

    public DeleteProjectCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var projectSpec = new GetProjectByIdSpecification(request.ProjectId, _userContext.UserId);

        var project = await _unitOfWork.Repository<ProjectEntity>().GetAsync(projectSpec);

        if (project is null)
            throw new ApiNotFoundException($"Project with Project Id: {request.ProjectId} not found");

        _unitOfWork.Repository<ProjectEntity>().Delete(project);

        await _unitOfWork.Complete(cancellationToken);

        return Unit.Value;
    }
}
