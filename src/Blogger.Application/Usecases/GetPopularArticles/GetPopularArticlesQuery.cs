namespace Blogger.Application.Usecases.GetPopularArticles;
public record GetPopularArticlesQuery(int Size) 
    : IRequest<IReadOnlyList<GetPopularArticlesQueryResponse>>;