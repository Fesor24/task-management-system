using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.EndpointGroupings;
using Shared.EndpointResponseWrapper;

namespace Application.Mediator;
public static class MediatorExtensions
{
    [HttpGet]
    public static RouteHandlerBuilder MediatorGet<TRequest, TResponse>(this WebApplication app, string route, 
        string endpointTagName) where TRequest : IRequest<TResponse>
    {
        route = $"api/{endpointTagName}/{route}";
        var routeHandlerBuilder = app.MapGet(route, DelegateHandlerWithAsParametersAttribute<TRequest, TResponse>);
        return AddToRouteHandlerBuilder<TResponse>(routeHandlerBuilder, endpointTagName);

    }

    [HttpPost]
    public static RouteHandlerBuilder MediatorPost<TRequest, TResponse>(this WebApplication app, string route,
        string endpointTagName) where TRequest: IRequest<TResponse>
    {
        route = $"api/{endpointTagName}/{route}";
        var routeHandlerBuilder = app.MapPost(route, DelegateHandler<TRequest, TResponse>);
        return AddToRouteHandlerBuilder<TResponse>(routeHandlerBuilder, endpointTagName);
    }

    [HttpPut]
    public static RouteHandlerBuilder MediatorPut<TRequest, TResponse>(this WebApplication app, string route,
        string endpointTagName) where TRequest : IRequest<TResponse>
    {
        route = $"api/{endpointTagName}/{route}";
        var routeHandlerBuilder = app.MapPut(route, DelegateHandler<TRequest, TResponse>);
        return AddToRouteHandlerBuilder<TResponse>(routeHandlerBuilder, endpointTagName);
    }

    [HttpDelete]
    public static RouteHandlerBuilder MediatorDelete<TRequest, TResponse>(this WebApplication app, string route,
        string endpointTagName) where TRequest: IRequest<TResponse>
    {
        route = $"api/{endpointTagName}/{route}";
        var routeHandlerBuilder = app.MapDelete(route, DelegateHandlerWithAsParametersAttribute<TRequest, TResponse>);
        return AddToRouteHandlerBuilder<TResponse>(routeHandlerBuilder, endpointTagName);
    }

    internal static async Task<IResult> DelegateHandlerWithAsParametersAttribute<TRequest, TResponse>(IMediator mediator,
        [AsParameters] TRequest request) where TRequest: IRequest<TResponse>
    {
        return Results.Ok(new ApiResponse<TResponse>(await mediator.Send(request))
        {
            ErrorMessage = null,
            StatusCode = 200
        });
    }

    internal static async Task<IResult> DelegateHandler<TRequest, TResponse>(IMediator mediator, TRequest request) 
        where TRequest: IRequest<TResponse>
    {
        return Results.Ok(new ApiResponse<TResponse>(await mediator.Send(request))
        {
            ErrorMessage = null,
            StatusCode = 200
        });
    }

    private static RouteHandlerBuilder AddToRouteHandlerBuilder<TResponse>(RouteHandlerBuilder routeHandler, 
        string endpointTagName)
    {
        if (endpointTagName.ToUpper() == EndpointGroupNames.ACCOUNT.ToUpper())
        {
            routeHandler
                .WithGroupName(EndpointGroupNames.ACCOUNT)
                .WithTags(EndpointGroupNames.ACCOUNT)
                .AllowAnonymous();
        }

        else
        {
            routeHandler
                .WithGroupName(EndpointGroupNames.MAIN)
                .WithTags(endpointTagName);
        }

        routeHandler.Produces<ApiResponse<TResponse>>();

        return routeHandler;
    }
}
