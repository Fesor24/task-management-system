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
        var routeHandlerBuilder = app.MapGet(route, DelegateHandler<TRequest, TResponse>);
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
        routeHandler.WithGroupName(EndpointGroupNames.MAIN)
            .WithTags(endpointTagName);

        routeHandler.Produces<ApiResponse<TResponse>>();

        return routeHandler;
    }
}
