namespace Blogger.APIs.Endpoints.Articles.UpdateDraft;

public record UpdateDraftRequest(string DraftId, string Title, string Body, string Summary, string[] Tags);
