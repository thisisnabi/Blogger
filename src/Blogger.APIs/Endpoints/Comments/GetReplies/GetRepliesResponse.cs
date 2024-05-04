namespace Blogger.APIs.Endpoints.Comments.GetReplies;

public record GetRepliesResponse(
  string FullName,
  DateTime CreatedOnUtc,
  string Content);