namespace Blogger.APIs.Contracts.GetComments;

public record GetCommentsRequest([FromRoute(Name = "article-id")]string ArticleId);
