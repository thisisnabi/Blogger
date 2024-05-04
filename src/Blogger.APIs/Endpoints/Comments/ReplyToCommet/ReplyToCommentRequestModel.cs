namespace Blogger.APIs.Endpoints.Comments.ReplyToCommet;

public record ReplyToCommentRequestModel([FromRoute(Name = "comment-id")] Guid CommentId,
                                   [FromBody] ReplyToCommentRequest body);

public record ReplyToCommentRequest(string Content,
                                     string FullName,
                                     string Email);