namespace Blogger.APIs.Endpoints.Comments.ApproveReply;

public record ApproveReplyRequest([FromQuery] string Link, [FromQuery(Name = "comment-id")] Guid CommentId);
