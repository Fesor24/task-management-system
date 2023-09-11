using Domain.Entities.Common.Task;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.Specifications.Task;
public class GetTaskByIdSpecification : BaseSpecification<TaskEntity>
{
    public GetTaskByIdSpecification(int taskId): base(x => x.TaskId == taskId)
    {
        AddInclude(x => x.Project);
    }
}
