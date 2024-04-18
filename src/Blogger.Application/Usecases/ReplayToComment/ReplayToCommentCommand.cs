using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.ReplayToComment;

public record ReplayToCommentCommand(CommentId CommentId, Client Client, string content) : IRequest<ReplayToCommentCommandResponse>;