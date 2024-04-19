// built-in
global using System.Net;
global using Microsoft.AspNetCore.Mvc;
global using System.Reflection;
global using System.Collections.Immutable;

// third-party
global using Mapster;
global using MapsterMapper;
global using MediatR;
global using FluentValidation;

// solution
global using Blogger.APIs;
global using Blogger.Application;
global using Blogger.APIs.Filters;
global using Blogger.Infrastructure;
global using Blogger.Application.Usecases.CreateArticle;
global using Blogger.APIs.Abstractions;
global using Blogger.Domain.ArticleAggregate;
global using Blogger.APIs.Endpoints.GetPopularTags;
global using Blogger.Application.Usecases.GetPopularTags;
global using Blogger.Application.Usecases.MakeDraft;
global using Blogger.Application.Usecases.UpdateDraft;
global using Blogger.Application.Usecases.PublishDraft;
global using Blogger.Application.Usecases.GetArchive;

