using Application.Handlers.Common.Task.Queries.GetTask;
using AutoMapper;
using Domain.Context;
using Infrastructure.Specifications.Task;
using MediatR;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Application.Handlers.Common.Task.Queries.GetTasksForCurrentWeek;
public sealed class GetTasksForCurrentWeekRequestHandler : IRequestHandler<GetTasksForCurrentWeekRequest,
    IReadOnlyList<GetTaskResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTasksForCurrentWeekRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<GetTaskResponse>> Handle(GetTasksForCurrentWeekRequest request, 
        CancellationToken cancellationToken)
    {
        DateTime currentDate = DateTime.UtcNow.Date;

        DayOfWeek dayOfWeek = currentDate.DayOfWeek;

        DateTime firstDayOfWeek = currentDate.AddDays(-(int)dayOfWeek);

        DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);

        var taskSpec = new GetTasksForCurrentWeekSpecification(firstDayOfWeek, lastDayOfWeek);

        var currentTasks = await _unitOfWork.Repository<TaskEntity>().GetAllAsync(taskSpec);

        return _mapper.Map<IReadOnlyList<GetTaskResponse>>(currentTasks);
    }
}
