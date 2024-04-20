namespace Blogger.Application.Usecases.GetApprovedArticleComments;
public record GetApprovedArticleCommentsQuery(ArticleId ArticleId) 
    : IRequest<IReadOnlyList<GetApprovedArticleCommentsQueryResponse>>;