namespace Blogger.APIs.Endpoints.Comments.GetReplaies;

public record GetReplaiesResponse(
  string FullName,
  DateTime CreatedOnUtc,
  string Content);