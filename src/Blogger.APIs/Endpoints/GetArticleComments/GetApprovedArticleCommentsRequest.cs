namespace Blogger.APIs.Contracts.GetArticleComments;

public record GetApprovedArticleCommentsRequest([FromRoute(Name = "article-id")]string ArticleId);
