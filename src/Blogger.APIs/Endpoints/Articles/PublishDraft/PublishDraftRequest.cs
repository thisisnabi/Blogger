namespace Blogger.APIs.Endpoints.Articles.PublishDraft;

public record PublishDraftRequest([FromRoute(Name = "draft-id")] string DraftId);
