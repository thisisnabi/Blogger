namespace Blogger.Application.Usecases.PublishDraft;

public record PublishDraftCommand(ArticleId DraftId) : IRequest;