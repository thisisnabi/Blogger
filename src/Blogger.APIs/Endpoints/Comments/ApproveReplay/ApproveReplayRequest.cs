namespace Blogger.APIs.Endpoints.Comments.ApproveReplay;

public record ApproveReplayRequest([FromQuery] string Link, [FromQuery(Name = "comment-id")] Guid CommentId);
