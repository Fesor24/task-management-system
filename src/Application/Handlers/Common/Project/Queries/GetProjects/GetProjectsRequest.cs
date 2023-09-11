using Application.Handlers.Common.Project.Queries.GetProject;
using MediatR;

namespace Application.Handlers.Common.Project.Queries.GetProjects;
public record GetProjectsRequest() : IRequest<IReadOnlyList<GetProjectResponse>>;
