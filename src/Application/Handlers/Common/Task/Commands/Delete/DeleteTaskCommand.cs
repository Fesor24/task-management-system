using MediatR;

namespace Application.Handlers.Common.Task.Commands.Delete;
public record DeleteTaskCommand(int TaskId) : IRequest<Unit>;
