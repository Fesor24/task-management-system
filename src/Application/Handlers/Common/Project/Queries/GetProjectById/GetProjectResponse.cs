using Application.Handlers.Common.Task.Queries.GetTask;

namespace Application.Handlers.Common.Project.Queries.GetProject;
public class GetProjectResponse
{
    public int ProjectId { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public IReadOnlyList<GetTaskResponse> Tasks { get; set; }
}
