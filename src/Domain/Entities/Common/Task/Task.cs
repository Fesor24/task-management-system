using Domain.Enums;

namespace Domain.Entities.Common.Task;
public class Task : AuditableEntity
{
    public Task()
    {
        
    }

    public Task(TaskId taskId, string title, string description, DueDate duedate, Status status, Priority priority)
    {
        TaskId = taskId;
        Title = title;
        Description = description;
        DueDate = duedate;
        Status = status;
        Priority = priority;
    }

    public TaskId TaskId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DueDate DueDate { get; private set; }
    public Status Status { get; private set; }
    public Priority Priority { get; private set; }
}
