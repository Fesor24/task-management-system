using MediatR;

namespace Application.Handlers.Common.Project.Commands.Update;
public record UpdateProjectCommand(int ProjectId, string Name, string Description) : IRequest<Unit>;
