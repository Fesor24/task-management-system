using Domain.Enums;

namespace Application.Handlers.Common.Task.Queries.GetTask;
public class GetTaskResponse
{
    public int TaskId { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string ProjectName { get; set; }

    public DateTimeOffset DueDate { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
}
