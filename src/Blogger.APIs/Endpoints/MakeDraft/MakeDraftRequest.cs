namespace Blogger.APIs.Contracts.MakeDraft;

public record MakeCommentRequest(string Title, string Body, string Summary, string[] Tags);
