using Application.Handlers.Common.Task.Commands.Create;
using Application.Mediator;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace Application.Endpoints;
public static class CommonEndpoints
{
    public static void AddEndpoints(WebApplication app)
    {
        const string ENDPOINT = "Common";

        app.MediatorPost<CreateTaskCommand, Unit>("Task", ENDPOINT);
    }
}
