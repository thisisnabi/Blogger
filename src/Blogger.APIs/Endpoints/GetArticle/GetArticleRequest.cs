namespace Blogger.APIs.Contracts.GetArticle;

public record GetArticleRequest([FromRoute(Name = "article-id")]string ArticleId);
