using Blogger.Domain.ClientAggregate;

namespace Blogger.Application.MakeComment;
public record MakeCommentCommand(ArticleId ArticleId, ClientId ClientId, string content) : IRequest;