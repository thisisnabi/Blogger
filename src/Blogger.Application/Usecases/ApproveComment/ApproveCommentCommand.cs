namespace Blogger.Application.ApproveComment;
public record ApproveCommentCommand(CommentId CommentId) : IRequest;