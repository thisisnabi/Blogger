namespace Blogger.APIs.Contracts.GetComments;

public record GetCommentsResponse(
  string FullName, 
  DateTime CreatedOnUtc,
  string Content);