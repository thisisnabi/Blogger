namespace Blogger.Application.Articles.GetPopularArticles;
public record GetPopularArticlesQuery(int Size)
    : IRequest<IReadOnlyCollection<GetPopularArticlesQueryResponse>>;