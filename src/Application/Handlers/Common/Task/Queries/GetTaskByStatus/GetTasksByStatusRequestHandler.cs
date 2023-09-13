using Application.Handlers.Common.Task.Queries.GetTask;
using AutoMapper;
using Domain.Context;
using Domain.Services.Users;
using Infrastructure.Specifications.Task;
using MediatR;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Application.Handlers.Common.Task.Queries.GetTaskByStatus;
public class GetTasksByStatusRequestHandler : IRequestHandler<GetTasksByStatusRequest,
    IReadOnlyList<GetTaskResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetTasksByStatusRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, 
        IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<IReadOnlyList<GetTaskResponse>> Handle(GetTasksByStatusRequest request, 
        CancellationToken cancellationToken)
    {
        var spec = new GetTasksByStatusSpecification(request.Status, _userContext.UserId);

        var tasks = await _unitOfWork.Repository<TaskEntity>().GetAllAsync(spec);

        return _mapper.Map<IReadOnlyList<GetTaskResponse>>(tasks);
    }
}
