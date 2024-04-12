namespace Blogger.Application.Usecases.GetApprovedArticleComments;

public record GetApprovedArticleCommentsResponse(string FullName, DateTime CreatedOnUtc,string Content);