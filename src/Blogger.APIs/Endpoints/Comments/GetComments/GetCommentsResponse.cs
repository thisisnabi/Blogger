namespace Blogger.APIs.Endpoints.Comments.GetComments;

public record GetCommentsResponse(
  string FullName,
  DateTime CreatedOnUtc,
  string Content);