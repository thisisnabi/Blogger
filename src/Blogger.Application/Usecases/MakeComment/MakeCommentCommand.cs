using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.MakeComment;

public record MakeCommentCommand(ArticleId ArticleId, Client Client, string Content) : IRequest<MakeCommentCommandResponse>;