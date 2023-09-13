using Application.Handlers.Common.Task.Queries.GetTask;
using AutoMapper;
using Domain.Context;
using Domain.Services.Users;
using Infrastructure.Specifications.Task;
using MediatR;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Application.Handlers.Common.Task.Queries.GetTasks;
public sealed class GetTasksRequestHandler : IRequestHandler<GetTasksRequest, IReadOnlyList<GetTaskResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetTasksRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<IReadOnlyList<GetTaskResponse>> Handle(GetTasksRequest request, 
        CancellationToken cancellationToken)
    {
        var taskSpec = new GetTasksSpecification(_userContext.UserId);

        var tasks = await _unitOfWork.Repository<TaskEntity>().GetAllAsync(taskSpec);

        return _mapper.Map<IReadOnlyList<GetTaskResponse>>(tasks);
    }
}
