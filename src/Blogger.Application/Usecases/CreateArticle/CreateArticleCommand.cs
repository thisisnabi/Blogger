namespace Blogger.Application.Usecases.CreateArticle;

public record CreateArticleCommand(string title, string body, string summery, string[] Tags)
    : IRequest<CreateArticleCommandResponse>;