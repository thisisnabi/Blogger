namespace Blogger.APIs.Endpoints.Articles.GetArticle;

public record GetArticleRequest([FromRoute(Name = "article-id")] string ArticleId);
