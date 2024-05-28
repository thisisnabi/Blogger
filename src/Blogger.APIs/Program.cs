using Blogger.APIs.ErrorHandling;

using ServiceCollector.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();
builder.Services
    .ConfigureApplicationLayer()
    .ConfigureInfrastructureLayer(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddExceptionHandler<GlobalExceptionHandler>()
    .AddProblemDetails()
    .AddServiceDiscovery();

var app = builder.Build();

// TODO: if (app.Environment.IsDevelopment())
app.UseExceptionHandler();
app.UseCors("AllowOrigin");

app.UseSwagger();
app.UseSwaggerUI();

app.MapEndpoints(); 

app.Run();