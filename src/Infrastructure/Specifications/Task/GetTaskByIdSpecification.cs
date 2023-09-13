using Domain.Entities.Common.Task;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.Specifications.Task;
public class GetTaskByIdSpecification : BaseSpecification<TaskEntity>
{
    public GetTaskByIdSpecification(int taskId, int userId): base(x => x.TaskId == taskId && x.UserId == userId)
    {
        AddInclude(x => x.Project);
    }
}
