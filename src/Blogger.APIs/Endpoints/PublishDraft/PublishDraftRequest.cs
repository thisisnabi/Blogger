namespace Blogger.APIs.Contracts.PublishDraft;

public record PublishDraftRequest([FromRoute]string DraftId);
