namespace Blogger.Application.Comments.ApproveComment;

public record ApproveCommentCommand(string Link) : IRequest<ApproveCommentCommandResponse>;