namespace Blogger.Application.Usecases.UpdateDraft;

public record UpdateDraftCommand(ArticleId DraftId, string Title, string Body, string Summary, IReadOnlyList<Tag> Tags)
    : IRequest;