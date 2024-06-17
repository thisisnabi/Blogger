namespace Blogger.Application.Articles.GetArticles;
public record GetArticlesQuery(int PageNumber = 1, int PageSize = 10, string Title = "")
    : IRequest<IReadOnlyCollection<GetArticlesQueryResponse>>;