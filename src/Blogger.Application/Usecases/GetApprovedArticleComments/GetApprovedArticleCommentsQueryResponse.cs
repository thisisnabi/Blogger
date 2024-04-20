namespace Blogger.Application.Usecases.GetApprovedArticleComments;

public record GetApprovedArticleCommentsQueryResponse(string FullName, DateTime CreatedOnUtc,string Content);