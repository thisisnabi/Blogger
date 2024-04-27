using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.ReplayToComment;

public record ReplayToCommentCommand(CommentId CommentId, Client Client, string Content)
    : IRequest<ReplayToCommentCommandResponse>;