using MediatR;

namespace Application.Handlers.Common.Project.Commands.Delete;
public record DeleteProjectCommand(int ProjectId) : IRequest<Unit>;
