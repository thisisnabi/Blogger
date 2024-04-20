namespace Blogger.APIs.Contracts.ReplayToCommet;

public record ReplayToCommentRequest(
    [FromRoute(Name = "comment-id")]Guid CommentId,
    string Content, string FullName, string Email);