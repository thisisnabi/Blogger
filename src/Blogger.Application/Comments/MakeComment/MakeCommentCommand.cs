using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.MakeComment;

public record MakeCommentCommand(ArticleId ArticleId, Client Client, string Content) : IRequest<MakeCommentCommandResponse>;