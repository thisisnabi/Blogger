using Blogger.APIs;
using Blogger.Application;
using Blogger.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplicationLayer(builder.Configuration);
builder.Services.ConfigurePresentationLayer(builder.Configuration);
builder.Services.ConfigureInfrastructureLayer(builder.Configuration);


builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
