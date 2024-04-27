namespace Blogger.Application.Articles.UpdateDraft;

public record UpdateDraftCommand(ArticleId DraftId, string Title, string Body, string Summary, IReadOnlyList<Tag> Tags)
    : IRequest;