using Application.Handlers.Common.Task.Queries.GetTask;
using AutoMapper;
using TaskEntity = Domain.Entities.Common.Task.Task;
using ProjectEntity = Domain.Entities.Common.Project.Project;
using Application.Handlers.Common.Project.Queries.GetProject;
using Domain.Entities.Common.Notification;
using Application.Handlers.Common.Notifications.Query.GetNotificationsByUserId;

namespace Application.MappingProfiles;
public class CommonMappingProfiles : Profile
{
    public CommonMappingProfiles()
    {
        CreateMap<TaskEntity, GetTaskResponse>()
            .ForMember(x => x.Title, o => o.MapFrom(t => t.Body.Title))
            .ForMember(x => x.Description, o => o.MapFrom(t => t.Body.Description))
            .ForMember(x => x.ProjectName, o => o.MapFrom(t => t.Project.Name))
            .ForMember(x => x.Status, o => o.MapFrom(t => t.Status.ToString()))
            .ForMember(x => x.Priority, o => o.MapFrom(t => t.Priority.ToString()));

        CreateMap<ProjectEntity, GetProjectResponse>();

        CreateMap<Notification, GetNotificationResponse>()
            .ForMember(x => x.NotificationStatus, o => o.MapFrom(t => t.NotificationStatus.ToString()));
    }
}
