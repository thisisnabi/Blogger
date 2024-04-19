namespace Blogger.Application.Usecases.ApproveComment;

public record ApproveCommentCommandResponse(ArticleId ArticleId) : IRequest;