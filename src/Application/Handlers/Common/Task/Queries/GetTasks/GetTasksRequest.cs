using Application.Handlers.Common.Task.Queries.GetTask;
using MediatR;

namespace Application.Handlers.Common.Task.Queries.GetTasks;
public record GetTasksRequest : IRequest<IReadOnlyList<GetTaskResponse>>;
