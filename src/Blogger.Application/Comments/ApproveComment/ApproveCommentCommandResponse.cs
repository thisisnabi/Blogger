using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.ApproveComment;

public record ApproveCommentCommandResponse(ArticleId ArticleId, CommentId CommentId) : IRequest;