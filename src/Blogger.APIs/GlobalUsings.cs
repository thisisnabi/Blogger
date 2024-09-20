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
global using Blogger.APIs.Abstractions;
global using Blogger.APIs.ErrorHandling;
global using Blogger.Application.Articles.CreateArticle;
global using Blogger.Application.Articles.GetArchive;
global using Blogger.Application.Articles.GetArticle;
global using Blogger.Application.Articles.GetArticles;
global using Blogger.Application.Articles.GetPopularArticles;
global using Blogger.Application.Articles.GetPopularTags;
global using Blogger.Application.Articles.GetTaggedArticles;
global using Blogger.Application.Articles.GetTags;
global using Blogger.Application.Articles.MakeDraft;
global using Blogger.Application.Articles.PublishDraft;
global using Blogger.Application.Articles.UpdateDraft;
global using Blogger.Application.Comments.ApproveComment;
global using Blogger.Application.Comments.ApproveReply;
global using Blogger.Application.Comments.GetComments;
global using Blogger.Application.Comments.GetReplies;
global using Blogger.Application.Comments.MakeComment;
global using Blogger.Application.Comments.ReplyToComment;
global using Blogger.Application.Subscribers.Subscribe;
global using Blogger.BuildingBlocks.Domain;
global using Blogger.Domain.ArticleAggregate;
global using Blogger.Domain.CommentAggregate;

global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.Extensions.DependencyInjection.Extensions;

