using Domain.Enums;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.Specifications.Task;
public class GetTasksByPrioritySpecification : BaseSpecification<TaskEntity>
{
    public GetTasksByPrioritySpecification(Priority priority) : base(x => x.Priority == priority)
    {
        AddInclude(x => x.Project);
        SetOrderBy(x => x.DueDate);
    }
}
