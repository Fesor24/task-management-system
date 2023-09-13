using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.Specifications.Task;
public class GetTasksForCurrentWeekSpecification : BaseSpecification<TaskEntity>
{
    public GetTasksForCurrentWeekSpecification(DateTime firstDay, DateTime lastDay, int userId) :
        base(x => x.DueDate >= firstDay && x.DueDate <= lastDay && x.UserId == userId)
    {
        AddInclude(x => x.Project);
        SetOrderByDesc(X => X.DueDate);
    }
}
