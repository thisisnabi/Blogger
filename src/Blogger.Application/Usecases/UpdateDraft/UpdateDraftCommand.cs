namespace Blogger.Application.Usecases.UpdateDraft;

public record UpdateDraftCommand(ArticleId ArticleId, string title, string body, string summery, IReadOnlyList<Tag> Tags)
    : IRequest;