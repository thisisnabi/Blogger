namespace Blogger.APIs.Contracts.GetReplaies;

public record GetReplaiesResponse(
  string FullName, 
  DateTime CreatedOnUtc,
  string Content);