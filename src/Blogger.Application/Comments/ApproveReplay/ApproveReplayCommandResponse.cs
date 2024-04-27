using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.ApproveReplay;

public record ApproveReplayCommandResponse(ArticleId ArticleId, CommentId CommentId, ReplayId ReplayId) : IRequest;