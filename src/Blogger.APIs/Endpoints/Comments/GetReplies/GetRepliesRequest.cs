namespace Blogger.APIs.Endpoints.Comments.GetReplies;

public record GetRepliesRequest([FromRoute(Name = "comment-id")] Guid CommentId);
