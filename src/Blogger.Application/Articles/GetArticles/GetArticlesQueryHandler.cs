namespace Blogger.Application.Articles.GetArticles;

public class GetArticlesQueryHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetArticlesQuery, IReadOnlyList<GetArticlesQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyList<GetArticlesQueryResponse>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetLatestArticlesAsync(request.PageNumber, request.PageSize, cancellationToken);

        return articles.Select(x => (GetArticlesQueryResponse)x)
                       .ToImmutableList();
    }
}
