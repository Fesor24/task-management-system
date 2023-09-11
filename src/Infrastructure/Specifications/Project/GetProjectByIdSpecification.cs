using Domain.Entities.Common.Project;
using ProjectEntity = Domain.Entities.Common.Project.Project;

namespace Infrastructure.Specifications.Project;
public class GetProjectByIdSpecification : BaseSpecification<ProjectEntity>
{
    public GetProjectByIdSpecification(int projectId): base(x => x.ProjectId == projectId)
    {
        AddInclude(x => x.Tasks);
    }
}
