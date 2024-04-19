using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.ApproveReplay;

public record ApproveReplayCommand(CommentId CommentId,string Link) : IRequest<ApproveReplayCommandResponse>;