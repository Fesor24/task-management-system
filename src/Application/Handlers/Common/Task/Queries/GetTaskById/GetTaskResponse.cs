using Domain.Enums;

namespace Application.Handlers.Common.Task.Queries.GetTask;
public class GetTaskResponse
{
    public int TaskId { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public Domain.Enums.TaskStatus Status { get; set; }
    public Priority Priority { get; set; }
    public string ProjectName { get; set; }

    public DateTimeOffset DueDate { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
}
