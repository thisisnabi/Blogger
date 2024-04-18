namespace Blogger.Application.Usecases.CreateArticle;

public record CreateArticleCommand(string Title, string Body, string Summary, IReadOnlyList<Tag> Tags)
    : IRequest<CreateArticleCommandResponse>;