namespace Blogger.Application.Usecases.ApproveComment;

public record ApproveCommentCommand(string Link) : IRequest<ApproveCommentCommandResponse>;