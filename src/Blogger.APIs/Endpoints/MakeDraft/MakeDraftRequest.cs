namespace Blogger.APIs.Contracts.MakeDraft;

public record MakeDraftRequest(string Title, string Body, string Summary, string[] Tags);
