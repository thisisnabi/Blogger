namespace Blogger.APIs.Endpoints.Comments.MakeComment;

public record MakeCommetRequest(string ArticleId, string Content, string FullName, string Email);