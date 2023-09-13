using Application.Handlers.Common.Project.Queries.GetProject;
using AutoMapper;
using Domain.Context;
using Domain.Services.Users;
using Infrastructure.Specifications.Project;
using MediatR;
using ProjectEntity = Domain.Entities.Common.Project.Project;

namespace Application.Handlers.Common.Project.Queries.GetProjects;
public sealed class GetProjectsRequestHandler : IRequestHandler<GetProjectsRequest, 
    IReadOnlyList<GetProjectResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetProjectsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<IReadOnlyList<GetProjectResponse>> Handle(GetProjectsRequest request, CancellationToken cancellationToken)
    {
        var projectSpec = new GetProjectsSpecification(_userContext.UserId);

        var projects = await _unitOfWork.Repository<ProjectEntity>().GetAllAsync(projectSpec);

        return _mapper.Map<IReadOnlyList<GetProjectResponse>>(projects);
    }
}
