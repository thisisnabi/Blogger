namespace Blogger.Application.Usecases.ApproveComment;
public record ApproveCommentCommand(CommentId CommentId) : IRequest;