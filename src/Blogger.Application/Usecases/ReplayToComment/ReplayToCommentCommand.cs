namespace Blogger.Application.Usecases.ReplayToComment;

public record ReplayToCommentCommand(CommentId CommentId, Client Client, string content) : IRequest;