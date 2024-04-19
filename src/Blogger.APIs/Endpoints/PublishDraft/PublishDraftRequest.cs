namespace Blogger.APIs.Contracts.PublishDraft;

public record PublishDraftRequest([FromRoute(Name = "draft-id")]string DraftId);
