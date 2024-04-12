namespace Blogger.Application.Usecases.CreateArticle;

public record CreateArticleCommand(string title, string body, string summery, IReadOnlyList<Tag> Tags)
    : IRequest<CreateArticleCommandResponse>;