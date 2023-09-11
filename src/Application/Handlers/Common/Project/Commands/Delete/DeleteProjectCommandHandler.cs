using Domain.Context;
using ProjectEntity =  Domain.Entities.Common.Project.Project;
using Infrastructure.Specifications.Project;
using MediatR;
using Shared.Exceptions;

namespace Application.Handlers.Common.Project.Commands.Delete;
public sealed class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var projectSpec = new GetProjectByIdSpecification(request.ProjectId);

        var project = await _unitOfWork.Repository<ProjectEntity>().GetAsync(projectSpec);

        if (project is null)
            throw new ApiNotFoundException($"Project with Project Id: {request.ProjectId} not found");

        _unitOfWork.Repository<ProjectEntity>().Delete(project);

        await _unitOfWork.Complete(cancellationToken);

        return Unit.Value;
    }
}
