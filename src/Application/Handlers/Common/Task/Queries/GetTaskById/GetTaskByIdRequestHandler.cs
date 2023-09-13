using AutoMapper;
using Domain.Context;
using Domain.Services.Users;
using Infrastructure.Specifications.Task;
using MediatR;
using Shared.Exceptions;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Application.Handlers.Common.Task.Queries.GetTask;
public sealed class GetTaskByIdRequestHandler : IRequestHandler<GetTaskByIdRequest, GetTaskResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetTaskByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<GetTaskResponse> Handle(GetTaskByIdRequest request, CancellationToken cancellationToken)
    {
        var taskSpec = new GetTaskByIdSpecification(request.TaskId, _userContext.UserId);

        var task = await _unitOfWork.Repository<TaskEntity>().GetAsync(taskSpec);

        if (task is null)
            throw new ApiNotFoundException($"Task with Id: {request.TaskId} not found");

        return _mapper.Map<GetTaskResponse>(task);   
    }
}
