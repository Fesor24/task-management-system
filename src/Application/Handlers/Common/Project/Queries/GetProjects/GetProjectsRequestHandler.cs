using Application.Handlers.Common.Project.Queries.GetProject;
using AutoMapper;
using Domain.Context;
using Infrastructure.Specifications.Project;
using MediatR;
using ProjectEntity = Domain.Entities.Common.Project.Project;

namespace Application.Handlers.Common.Project.Queries.GetProjects;
public sealed class GetProjectsRequestHandler : IRequestHandler<GetProjectsRequest, 
    IReadOnlyList<GetProjectResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProjectsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<GetProjectResponse>> Handle(GetProjectsRequest request, CancellationToken cancellationToken)
    {
        var projectSpec = new GetProjectsSpecification();

        var projects = await _unitOfWork.Repository<ProjectEntity>().GetAllAsync(projectSpec);

        return _mapper.Map<IReadOnlyList<GetProjectResponse>>(projects);
    }
}
