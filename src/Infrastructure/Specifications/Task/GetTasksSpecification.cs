using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.Specifications.Task;
public class GetTasksSpecification : BaseSpecification<TaskEntity>
{
    public GetTasksSpecification(int userId) : base(x => x.UserId == userId)
    {
        AddInclude(x => x.Project);
        SetOrderByDesc(x => x.UpdatedAt);
    }
}
