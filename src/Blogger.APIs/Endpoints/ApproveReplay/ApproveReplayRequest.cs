namespace Blogger.APIs.Contracts.ApproveReplay;

public record ApproveReplayRequest([FromQuery]string Link, [FromRoute(Name = "comment-id")] Guid CommentId);
