using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.ApproveComment;

public record ApproveCommentCommandResponse(ArticleId ArticleId, CommentId CommentId) : IRequest;