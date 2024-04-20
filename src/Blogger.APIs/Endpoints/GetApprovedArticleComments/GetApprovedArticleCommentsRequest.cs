namespace Blogger.APIs.Contracts.GetApprovedArticleComments;

public record GetApprovedArticleCommentsRequest([FromRoute(Name = "article-id")]string ArticleId);
