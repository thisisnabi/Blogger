namespace Blogger.APIs.Contracts.GetReplaies;

public record GetReplaiesRequest([FromRoute(Name = "comment-id")]Guid CommentId);
