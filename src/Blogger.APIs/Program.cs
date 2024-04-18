using Blogger.APIs;
using Blogger.APIs.Contracts.CreateArticle;
using Blogger.Application;
using Blogger.Application.Usecases.CreateArticle;
using Blogger.Infrastructure;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplicationLayer(builder.Configuration);
builder.Services.ConfigureInfrastructureLayer(builder.Configuration);
builder.Services.ConfigureMapster();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/articles/", CreateArticleEndPoint.CreateArticle);

app.Run();
