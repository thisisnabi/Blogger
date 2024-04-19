var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplicationLayer(builder.Configuration);
builder.Services.ConfigureInfrastructureLayer(builder.Configuration);
builder.Services.ConfigureMapster();
builder.Services.ConfigureValidator();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/articles/", CreateArticleEndPoint.CreateArticle)
   .Validator<CreateArticleRequest>();

app.Run();
