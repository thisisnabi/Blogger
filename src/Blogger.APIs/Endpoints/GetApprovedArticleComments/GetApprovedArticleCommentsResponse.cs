namespace Blogger.APIs.Contracts.GetApprovedArticleComments;

public record GetApprovedArticleCommentsResponse(
  string FullName, 
  DateTime CreatedOnUtc,
  string Content);