namespace Blogger.Application.Usecases.GetArticles;
public record GetArticlesQuery(int PageNumber = 1, int PageSize = 10) 
    : IRequest<IReadOnlyList<GetArticlesQueryResponse>>;