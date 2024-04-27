namespace Blogger.APIs.Endpoints.Articles.MakeDraft;

public record MakeDraftRequest(string Title, string Body, string Summary, string[] Tags);
