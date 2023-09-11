using MediatR;

namespace Application.Handlers.Common.Project.Queries.GetProject;
public record GetProjectByIdRequest(int ProjectId) : IRequest<GetProjectResponse>;
