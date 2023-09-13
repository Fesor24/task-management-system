using ProjectEntity = Domain.Entities.Common.Project.Project;

namespace Infrastructure.Specifications.Project;
public class GetProjectByIdSpecification : BaseSpecification<ProjectEntity>
{
    public GetProjectByIdSpecification(int projectId, int userId): base(x => x.ProjectId == projectId && x.UserId == userId)
    {
        AddInclude(x => x.Tasks);
    }
}
