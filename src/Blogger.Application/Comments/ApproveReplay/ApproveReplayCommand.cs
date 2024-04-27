using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.ApproveReplay;

public record ApproveReplayCommand(CommentId CommentId, string Link) : IRequest<ApproveReplayCommandResponse>;