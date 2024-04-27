namespace Blogger.APIs.Endpoints.Comments.GetReplaies;

public record GetReplaiesRequest([FromRoute(Name = "comment-id")] Guid CommentId);
