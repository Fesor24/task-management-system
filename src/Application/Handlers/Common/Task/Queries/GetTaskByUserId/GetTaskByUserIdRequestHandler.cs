using Application.Handlers.Common.Task.Queries.GetTask;
using Domain.Context;
using TaskEntity =  Domain.Entities.Common.Task.Task;
using Domain.Services.Users;
using Infrastructure.Specifications.Task;
using MediatR;
using AutoMapper;

namespace Application.Handlers.Common.Task.Queries.GetTaskByUserId;
public class GetTaskByUserIdRequestHandler : IRequestHandler<GetTaskByUserIdRequest, 
    IReadOnlyList<GetTaskResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    private readonly IMapper _mapper;

    public GetTaskByUserIdRequestHandler(IUnitOfWork unitOfWork, IUserContext userContext,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<GetTaskResponse>> Handle(GetTaskByUserIdRequest request, CancellationToken cancellationToken)
    {
        var taskSpec = new GetTasksByUserIdSpecification(_userContext.UserId);

        var tasks = await _unitOfWork.Repository<TaskEntity>().GetAllAsync(taskSpec);

        return _mapper.Map<IReadOnlyList<GetTaskResponse>>(tasks);
    }
}
