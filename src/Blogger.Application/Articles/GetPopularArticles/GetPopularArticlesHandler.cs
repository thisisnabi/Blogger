namespace Blogger.Application.Articles.GetPopularArticles;

public class GetPopularArticlesHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetPopularArticlesQuery, IReadOnlyList<GetPopularArticlesQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyList<GetPopularArticlesQueryResponse>> Handle(GetPopularArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetPopularArticlesAsync(request.Size, cancellationToken);

        return articles.Select(x => new GetPopularArticlesQueryResponse(x.Id, x.Title))
                       .ToImmutableList();
    }
}
