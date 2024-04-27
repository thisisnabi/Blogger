namespace Blogger.APIs.Endpoints.Comments.GetComments;

public record GetCommentsRequest([FromRoute(Name = "article-id")] string ArticleId);
