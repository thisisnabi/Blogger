namespace Blogger.APIs.Contracts.ReplayToCommet;

public record ReplayToCommentRequestModel([FromRoute(Name = "comment-id")] Guid CommentId, 
                                   [FromBody] ReplayToCommentRequest body);

public record ReplayToCommentRequest(string Content,
                                     string FullName,
                                     string Email);