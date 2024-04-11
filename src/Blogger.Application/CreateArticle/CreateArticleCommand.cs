namespace Blogger.Application.CreateArticle;

public record CreateArticleCommand(string title, string body, string summery, string[] Tags)
    : IRequest<CreateArticleCommandResponse>;