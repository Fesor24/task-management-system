using Domain.Enums;

namespace Domain.Entities.Common;
public class Task : AuditableEntity
{
    public int TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset DueDate { get; set; }
    public Status Status { get; set; }
    public Priority Priority { get; set; }

}
