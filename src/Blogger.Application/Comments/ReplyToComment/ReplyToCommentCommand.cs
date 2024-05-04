using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.ReplyToComment;

public record ReplyToCommentCommand(CommentId CommentId, Client Client, string Content)
    : IRequest<ReplyToCommentCommandResponse>;