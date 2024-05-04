using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.ApproveReply;

public record ApproveReplyCommand(CommentId CommentId, string Link) : IRequest<ApproveReplyCommandResponse>;