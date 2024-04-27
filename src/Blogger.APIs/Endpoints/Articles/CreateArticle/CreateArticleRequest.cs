namespace Blogger.APIs.Endpoints.Articles.CreateArticle;

public record CreateArticleRequest(string Title, string Body, string Summary, string[] Tags);
