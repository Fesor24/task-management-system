using MediatR;

namespace Application.Handlers.Common.Task.Commands.AssignProject;
public record AssignProjectCommand(int TaskId, int? ProjectId) : IRequest<Unit>;
