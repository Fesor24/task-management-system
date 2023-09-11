using ProjectEntity =  Domain.Entities.Common.Project.Project;
using Domain.Enums;
using Domain.Entities.Common.Project;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Common.Task;
public class Task : AuditableEntity
{
    public Task()
    {
        
    }

    public Task(Body body, DueDate duedate, Status status, 
        Priority priority, int? projectId)
    {
        Body = body;
        DueDate = duedate.Value;
        Status = status;
        Priority = priority;
        ProjectId = projectId;
    }

    public int TaskId { get; private set; }

    [Required]
    public Body Body { get; private set; }
    public DateTime DueDate { get; private set; }
    public Status Status { get; private set; }
    public Priority Priority { get; private set; }
    public int? ProjectId { get; private set; }
    public ProjectEntity Project { get; private set; }

    public void Update(Body body,
        DueDate dueDate, Status status, Priority priority) 
    {
        Body = body;
        DueDate = dueDate.Value;
        Status = status;
        Priority = priority;
    }

    public void AssignProject(int? projectId) => 
        ProjectId = projectId;
}
