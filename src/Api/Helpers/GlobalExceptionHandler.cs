using Shared.Exceptions;
using System.Net;
using System.Text.Json;

namespace Api.Helpers;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _env;

    public GlobalExceptionHandler(RequestDelegate next, IHostEnvironment env)
    {
        _next = next;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode status;

            var exceptionType = ex.GetType();

            if (exceptionType == typeof(ApiNotFoundException))
                status = HttpStatusCode.NotFound;

            else if (exceptionType == typeof(ApiBadRequestException))
                status = HttpStatusCode.BadRequest;

            else if (exceptionType == typeof(ApiFluentValidationException))
                status = HttpStatusCode.BadRequest;
            else
                status = HttpStatusCode.InternalServerError;

            context.Response.StatusCode = (int)status;

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var error = _env.IsDevelopment() ? JsonSerializer.Serialize(new { message = ex.Message, details = ex.StackTrace }, 
                jsonOptions)
                : JsonSerializer.Serialize(new { message = ex.Message }, jsonOptions);

            await context.Response.WriteAsync(error);
        }
    }
}
