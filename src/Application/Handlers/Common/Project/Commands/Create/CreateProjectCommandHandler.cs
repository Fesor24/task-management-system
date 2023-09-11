using Domain.Context;
using MediatR;
using ProjectEntity = Domain.Entities.Common.Project.Project;

namespace Application.Handlers.Common.Project.Commands.Create;
public sealed class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new ProjectEntity(
            request.Name,
            request.Description);

        await _unitOfWork.Repository<ProjectEntity>().AddAsync(project);

        await _unitOfWork.Complete(cancellationToken);

        return project.ProjectId;
    }
}
