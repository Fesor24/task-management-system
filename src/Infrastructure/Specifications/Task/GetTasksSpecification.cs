using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.Specifications.Task;
public class GetTasksSpecification : BaseSpecification<TaskEntity>
{
    public GetTasksSpecification()
    {
        AddInclude(x => x.Project);
        SetOrderByDesc(x => x.UpdatedAt);
    }
}
