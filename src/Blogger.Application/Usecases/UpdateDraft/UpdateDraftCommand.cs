namespace Blogger.Application.UpdateDraft;

public record UpdateDraftCommand(ArticleId ArticleId, string title, string body, string summery, string[] Tags)
    : IRequest;