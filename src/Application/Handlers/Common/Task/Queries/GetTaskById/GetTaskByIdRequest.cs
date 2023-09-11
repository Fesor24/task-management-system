using MediatR;

namespace Application.Handlers.Common.Task.Queries.GetTask;
public record GetTaskByIdRequest(int TaskId) : IRequest<GetTaskResponse>;
