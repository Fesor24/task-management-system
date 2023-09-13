using Domain.Enums;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.Specifications.Task;
public class GetTasksByStatusSpecification : BaseSpecification<TaskEntity>
{
    public GetTasksByStatusSpecification(Domain.Enums.TaskStatus status, int userId) : base(x => x.Status == status && 
    x.UserId == userId)
    {
        AddInclude(x => x.Project);
        SetOrderBy(x => x.DueDate);
    }
}
