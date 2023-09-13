using Domain.Context;
using Domain.Enums;
using Domain.Services.Notification;
using Domain.Services.Users;
using Infrastructure.Specifications.Notification;
using Infrastructure.Specifications.Task;
using NotificationEntity = Domain.Entities.Common.Notification.Notification;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Application.Services.Notification;
public class NotificationService : INotificationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;

    private readonly Dictionary<string, Func<string, string, string>> _notificationFunctionMap;

    public NotificationService(IUnitOfWork unitOfWork, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _notificationFunctionMap = new Dictionary<string, Func<string, string, string>>
        {
            {nameof(NotificationType.TaskReminder), ComposeNotificationMessageForReminder },
            {nameof(NotificationType.TaskAssignment), ComposeNotificationMessageForAssignment },
            {nameof(NotificationType.TaskCompleted), ComposeNotificationMessageForTaskCompletion }
        };
    }

    public async Task SetTaskReminder()
    {
        var uncompletedDueTaskSpec = new GetUncompletedTasksDueWithin48HoursSpecification();

        var uncompletedDueTasks = await _unitOfWork.Repository<TaskEntity>().GetAllAsync(uncompletedDueTaskSpec);

        List<NotificationEntity> notifications = new();

        foreach(var task in uncompletedDueTasks)
        {
            var notifiedTaskSpec = new GetNotificationByTaskIdSpecification(task.TaskId);

            var notifiedTask = await _unitOfWork.Repository<NotificationEntity>().GetAsync(notifiedTaskSpec);

            // If it is not null, this means a reminder has been sent, there is a record/reminder in the Notification table
            // for this task
            if (notifiedTask is not null)
                continue;

            var notification = new NotificationEntity(
                task.UserId,
                _notificationFunctionMap[nameof(NotificationType.TaskReminder)]
                    .Invoke(task.Body.Title, task.Status.ToString()), 
                NotificationType.TaskReminder,
                task.TaskId
                );

            notifications.Add(notification);
        }

        if(notifications.Any())
        {
            await _unitOfWork.Repository<NotificationEntity>().AddRangeAsync(notifications);

            await _unitOfWork.Complete();
        }  
    }

    public async Task TaskAssignment(string taskName, string taskStatus, int taskId)
    {
        var notification = new NotificationEntity(
            _userContext.UserId,
            _notificationFunctionMap[nameof(NotificationType.TaskAssignment)].Invoke(taskName, taskStatus),
            NotificationType.TaskAssignment,
            taskId
            );

        await _unitOfWork.Repository<NotificationEntity>().AddAsync(notification);

        await _unitOfWork.Complete();
    }

    public async Task TaskCompleted(string taskName, int taskId)
    {
        var notification = new NotificationEntity(
            _userContext.UserId,
            _notificationFunctionMap[nameof(NotificationType.TaskCompleted)].Invoke(taskName,
            Domain.Enums.TaskStatus.Completed.ToString()),
            NotificationType.TaskCompleted,
            taskId
            );

        await _unitOfWork.Repository<NotificationEntity>().AddAsync(notification);

        await _unitOfWork.Complete();
    }

    private string ComposeNotificationMessageForReminder(string taskName, string taskUpdate) =>
        $"Task ({taskName}) is due in 48 hours or less. Status: {taskUpdate}";

    private string ComposeNotificationMessageForAssignment(string taskName, string taskUpdate) =>
       $"A new task ({taskName}) has been assigned. Status: {taskUpdate}";

    private string ComposeNotificationMessageForTaskCompletion(string taskName, string taskUpdate) =>
       $"Task ({taskName}) has been completed, Status: {taskUpdate}";
}
