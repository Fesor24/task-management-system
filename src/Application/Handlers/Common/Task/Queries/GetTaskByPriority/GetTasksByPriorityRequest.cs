using Application.Handlers.Common.Task.Queries.GetTask;
using Domain.Enums;
using MediatR;

namespace Application.Handlers.Common.Task.Queries.GetTaskByPriority;
public record GetTasksByPriorityRequest(Priority Priority) : IRequest<IReadOnlyList<GetTaskResponse>>;
