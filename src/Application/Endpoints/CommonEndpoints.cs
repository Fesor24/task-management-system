using Application.Handlers.Common.Project.Commands.Create;
using Application.Handlers.Common.Project.Commands.Delete;
using Application.Handlers.Common.Project.Queries.GetProject;
using Application.Handlers.Common.Project.Queries.GetProjects;
using Application.Handlers.Common.Task.Commands.AssignProject;
using Application.Handlers.Common.Task.Commands.Create;
using Application.Handlers.Common.Task.Commands.Delete;
using Application.Handlers.Common.Task.Queries.GetTask;
using Application.Handlers.Common.Task.Queries.GetTaskByPriority;
using Application.Handlers.Common.Task.Queries.GetTaskByStatus;
using Application.Handlers.Common.Task.Queries.GetTaskByUserId;
using Application.Handlers.Common.Task.Queries.GetTasks;
using Application.Handlers.Common.Task.Queries.GetTasksForCurrentWeek;
using Application.Mediator;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace Application.Endpoints;
public static class CommonEndpoints
{
    public static void AddEndpoints(WebApplication app)
    {
        const string ENDPOINT = "Common";

        app.MediatorPost<CreateTaskCommand, int>("Task", ENDPOINT);
        app.MediatorGet<GetTaskByIdRequest, GetTaskResponse>("Task", ENDPOINT);
        app.MediatorGet<GetTasksRequest, IReadOnlyList<GetTaskResponse>>("Tasks", ENDPOINT);
        app.MediatorGet<GetTasksForCurrentWeekRequest, IReadOnlyList<GetTaskResponse>>("Tasks/CurrentWeek", ENDPOINT);
        app.MediatorGet<GetTasksByPriorityRequest, IReadOnlyList<GetTaskResponse>>("Tasks/Priority", ENDPOINT);
        app.MediatorGet<GetTasksByStatusRequest, IReadOnlyList<GetTaskResponse>>("Tasks/Status", ENDPOINT);
        app.MediatorPut<AssignProjectCommand, Unit>("Task/AssignProject", ENDPOINT);
        app.MediatorDelete<DeleteTaskCommand, Unit>("Task", ENDPOINT);
        app.MediatorGet<GetTaskByUserIdRequest, IReadOnlyList<GetTaskResponse>>("Tasks/User", ENDPOINT);

        app.MediatorPost<CreateProjectCommand, int>("Project", ENDPOINT);
        app.MediatorGet<GetProjectByIdRequest, GetProjectResponse>("Project", ENDPOINT);
        app.MediatorGet<GetProjectsRequest, IReadOnlyList<GetProjectResponse>>("Projects", ENDPOINT);
        app.MediatorDelete<DeleteProjectCommand, Unit>("Project", ENDPOINT);
    }
}
