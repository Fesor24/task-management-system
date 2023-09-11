using Application.Handlers.Common.Task.Queries.GetTask;
using MediatR;

namespace Application.Handlers.Common.Task.Queries.GetTasksForCurrentWeek;
public record GetTasksForCurrentWeekRequest() : IRequest<IReadOnlyList<GetTaskResponse>>;
