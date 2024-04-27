namespace Blogger.Application.Articles.CreateArticle;

public record CreateArticleCommand(string Title, string Body, string Summary, IReadOnlyList<Tag> Tags)
    : IRequest<CreateArticleCommandResponse>;