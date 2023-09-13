using Domain.Context;
using ProjectEntity =  Domain.Entities.Common.Project.Project;
using Domain.Services.Users;
using Infrastructure.Specifications.Project;
using MediatR;
using Shared.Exceptions;

namespace Application.Handlers.Common.Project.Commands.Update;
public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;

    public UpdateProjectCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var projectSpec = new GetProjectByIdSpecification(request.ProjectId, _userContext.UserId);

        var project = await _unitOfWork.Repository<ProjectEntity>().GetAsync(projectSpec);

        if (project is null)
            throw new ApiNotFoundException($"Project with Id: {request.ProjectId} not found");

        string name = string.IsNullOrWhiteSpace(request.Name) ? project.Name : request.Name;
        string description = string.IsNullOrWhiteSpace(request.Description) ? project.Description : 
            request.Description;

        project.Update(name, description);

        _unitOfWork.Repository<ProjectEntity>().Update(project);

        await _unitOfWork.Complete();

        return Unit.Value;
    }
}
