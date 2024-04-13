namespace Blogger.Application.Usecases.UpdateDraft;

public record UpdateDraftCommand(ArticleId ArticleId, string title, string body, string summary, IReadOnlyList<Tag> Tags)
    : IRequest;