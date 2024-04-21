namespace Blogger.APIs.Contracts.CreateArticle;

public record CreateArticleRequest(string Title, string Body, string Summary, string[] Tags);
