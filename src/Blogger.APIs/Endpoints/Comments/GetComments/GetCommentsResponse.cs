namespace Blogger.APIs.Endpoints.Comments.GetComments;

public record GetCommentsResponse(
  string Id,
  string FullName,
  DateTime CreatedOnUtc,
  string Content);