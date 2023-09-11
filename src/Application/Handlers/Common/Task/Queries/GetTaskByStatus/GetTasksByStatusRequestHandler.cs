using Application.Handlers.Common.Task.Queries.GetTask;
using AutoMapper;
using Domain.Context;
using Infrastructure.Specifications.Task;
using MediatR;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Application.Handlers.Common.Task.Queries.GetTaskByStatus;
public class GetTasksByStatusRequestHandler : IRequestHandler<GetTasksByStatusRequest,
    IReadOnlyList<GetTaskResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTasksByStatusRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<GetTaskResponse>> Handle(GetTasksByStatusRequest request, 
        CancellationToken cancellationToken)
    {
        var spec = new GetTasksByStatusSpecification(request.Status);

        var tasks = await _unitOfWork.Repository<TaskEntity>().GetAllAsync(spec);

        return _mapper.Map<IReadOnlyList<GetTaskResponse>>(tasks);
    }
}
