namespace Blogger.APIs.Contracts.MakeComment;

public record ReplayToCommetRequest(string ArticleId,string Content, string FullName, string Email);