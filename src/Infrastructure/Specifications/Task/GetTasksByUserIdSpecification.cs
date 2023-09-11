using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.Specifications.Task;
public class GetTasksByUserIdSpecification  :BaseSpecification<TaskEntity>
{
    public GetTasksByUserIdSpecification()
    {
        AddInclude(x => x.Project);
        SetOrderByDesc(x => x.DueDate);
    }
}
