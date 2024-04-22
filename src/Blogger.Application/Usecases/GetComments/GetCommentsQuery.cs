namespace Blogger.Application.Usecases.GetComments;
public record GetCommentsQuery(ArticleId ArticleId) 
    : IRequest<IReadOnlyList<GetCommentsQueryResponse>>;