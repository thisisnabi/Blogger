namespace Blogger.Application.Usecases.GetArticleComments;
public record GetArticleCommentsQuery(ArticleId ArticleId) 
    : IRequest<IReadOnlyList<GetArticleCommentsQueryResponse>>;