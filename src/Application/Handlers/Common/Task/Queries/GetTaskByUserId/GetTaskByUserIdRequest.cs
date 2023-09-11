using Application.Handlers.Common.Task.Queries.GetTask;
using MediatR;

namespace Application.Handlers.Common.Task.Queries.GetTaskByUserId;
public record GetTaskByUserIdRequest : IRequest<IReadOnlyList<GetTaskResponse>>;
