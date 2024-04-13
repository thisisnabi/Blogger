namespace Blogger.Application.Usecases.CreateArticle;

public record CreateArticleCommand(string title, string body, string summary, IReadOnlyList<Tag> Tags)
    : IRequest<CreateArticleCommandResponse>;