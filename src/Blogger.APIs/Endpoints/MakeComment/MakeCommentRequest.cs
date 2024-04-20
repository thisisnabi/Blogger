namespace Blogger.APIs.Contracts.MakeComment;

public record ReplayToCommetRequest(
    [FromRoute(Name = "article-id")]string ArticleId,
    string Content, string FullName, string Email);