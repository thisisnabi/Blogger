namespace Blogger.APIs.Contracts.GetArticleComments;

public record GetApprovedArticleCommentsResponse(
  string FullName, 
  DateTime CreatedOnUtc,
  string Content);