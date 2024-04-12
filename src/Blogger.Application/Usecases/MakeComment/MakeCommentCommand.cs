namespace Blogger.Application.Usecases.MakeComment;

public record MakeCommentCommand(ArticleId ArticleId, Client Client, string content) : IRequest;