using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.Specifications.Task;
public class GetUncompletedTasksDueWithin48HoursSpecification : BaseSpecification<TaskEntity>
{
    // Subtract 48 hours from the due date of the task
    // If current date time is greater or equal to the result, then the user has 48hrs before the due date
    // Task must however not be completed and current date time must not be greater than duedate
    public GetUncompletedTasksDueWithin48HoursSpecification() : base(x => DateTime.UtcNow >= x.DueDate.AddHours(-48) 
    && DateTime.UtcNow < x.DueDate && x.Status != Domain.Enums.TaskStatus.Completed)
    {
        
    }
}
