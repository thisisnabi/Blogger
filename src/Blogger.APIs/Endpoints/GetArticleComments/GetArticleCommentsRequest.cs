namespace Blogger.APIs.Contracts.GetArticleComments;

public record GetArticleCommentsRequest([FromRoute(Name = "article-id")]string ArticleId);
