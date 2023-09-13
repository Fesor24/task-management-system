using Application.Handlers.Common.Task.Queries.GetTask;
using Domain.Enums;
using MediatR;

namespace Application.Handlers.Common.Task.Queries.GetTaskByStatus;
public record GetTasksByStatusRequest(Domain.Enums.TaskStatus Status) : IRequest<IReadOnlyList<GetTaskResponse>>;
