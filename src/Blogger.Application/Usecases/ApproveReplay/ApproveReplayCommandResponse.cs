namespace Blogger.Application.Usecases.ApproveReplay;

public record ApproveReplayCommandResponse(ArticleId ArticleId) : IRequest;