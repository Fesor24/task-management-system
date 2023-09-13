using Api.Definitions.Extensions;
using Api.Helpers;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddServicesToContainer(builder.Configuration, typeof(Program));

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();

app.ConfigureHttpPipelineAndRoutes(app.Configuration);

app.UseMiddleware<JobsMiddleware>();

app.Run();
