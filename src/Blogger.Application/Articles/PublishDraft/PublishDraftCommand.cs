namespace Blogger.Application.Articles.PublishDraft;

public record PublishDraftCommand(ArticleId DraftId) : IRequest;