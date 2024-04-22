namespace Blogger.APIs.Contracts.MakeComment;

public record MakeCommetRequest(string ArticleId,string Content, string FullName, string Email);