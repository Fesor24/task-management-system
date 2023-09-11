using Domain.Enums;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.Specifications.Task;
public class GetTasksByStatusSpecification : BaseSpecification<TaskEntity>
{
    public GetTasksByStatusSpecification(Status status) : base(x => x.Status == status)
    {
        AddInclude(x => x.Project);
        SetOrderBy(x => x.DueDate);
    }
}
