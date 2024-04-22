namespace Blogger.APIs.Contracts.GetArticleComments;

public record GetArticleCommentsResponse(
  string FullName, 
  DateTime CreatedOnUtc,
  string Content);