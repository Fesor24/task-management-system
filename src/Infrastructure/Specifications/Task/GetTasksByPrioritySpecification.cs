using Domain.Enums;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.Specifications.Task;
public class GetTasksByPrioritySpecification : BaseSpecification<TaskEntity>
{
    public GetTasksByPrioritySpecification(Priority priority, int userId) : base(x => x.Priority == priority && 
    x.UserId == userId)
    {
        AddInclude(x => x.Project);
        SetOrderBy(x => x.DueDate);
    }
}
