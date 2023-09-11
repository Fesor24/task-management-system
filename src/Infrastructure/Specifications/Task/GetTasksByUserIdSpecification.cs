using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.Specifications.Task;
public class GetTasksByUserIdSpecification  :BaseSpecification<TaskEntity>
{
    public GetTasksByUserIdSpecification(int userId) : base(x => x.UserId == userId)
    {
        AddInclude(x => x.Project);
        SetOrderByDesc(x => x.DueDate);
    }
}
