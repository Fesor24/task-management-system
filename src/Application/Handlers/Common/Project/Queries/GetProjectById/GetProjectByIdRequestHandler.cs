using AutoMapper;
using Domain.Context;
using ProjectEntity =  Domain.Entities.Common.Project.Project;
using Infrastructure.Specifications.Project;
using MediatR;
using Shared.Exceptions;
using Domain.Services.Users;

namespace Application.Handlers.Common.Project.Queries.GetProject;
public sealed class GetProjectByIdRequestHandler : IRequestHandler<GetProjectByIdRequest, GetProjectResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetProjectByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper,
        IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<GetProjectResponse> Handle(GetProjectByIdRequest request, CancellationToken cancellationToken)
    {
        var projectSpec = new GetProjectByIdSpecification(request.ProjectId, _userContext.UserId);

        var project = await _unitOfWork.Repository<ProjectEntity>().GetAsync(projectSpec);

        if (project is null)
            throw new ApiNotFoundException($"Project with Id: {request.ProjectId} not found");

        return _mapper.Map<GetProjectResponse>(project);
    }
}
