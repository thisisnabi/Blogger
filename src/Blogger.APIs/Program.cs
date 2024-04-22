var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.ConfigureApplicationLayer(builder.Configuration);
builder.Services.ConfigureInfrastructureLayer(builder.Configuration);
builder.Services.ConfigureMapster();
builder.Services.ConfigureValidator();

builder.Services.AddEndpoints();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
  
var app = builder.Build();

// TODO: if (app.Environment.IsDevelopment())
app.UseSwagger();
app.UseSwaggerUI();
 
app.MapEndpoints(); 

app.Run();