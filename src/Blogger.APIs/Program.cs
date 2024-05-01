using Blogger.APIs.ErrorHandling;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.ConfigureApplicationLayer(builder.Configuration);
builder.Services.ConfigureInfrastructureLayer(builder.Configuration);
builder.Services.ConfigureMapster();
builder.Services.ConfigureValidator();
builder.Services.ConfigureCors();

builder.Services.AddEndpoints();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// TODO: if (app.Environment.IsDevelopment())
app.UseExceptionHandler();
app.UseCors("AllowOrigin");

app.UseSwagger();
app.UseSwaggerUI();

app.MapEndpoints(); 

app.Run();