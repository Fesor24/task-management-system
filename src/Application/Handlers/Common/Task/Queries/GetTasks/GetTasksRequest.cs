using Application.Handlers.Common.Task.Queries.GetTask;
using MediatR;

namespace Application.Handlers.Common.Task.Queries.GetTasks;
public class GetTasksRequest : IRequest<IReadOnlyList<GetTaskResponse>>
{
}
