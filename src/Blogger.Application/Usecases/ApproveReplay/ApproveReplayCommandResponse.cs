using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.ApproveReplay;

public record ApproveReplayCommandResponse(ArticleId ArticleId, CommentId CommentId, ReplayId ReplayId) : IRequest;