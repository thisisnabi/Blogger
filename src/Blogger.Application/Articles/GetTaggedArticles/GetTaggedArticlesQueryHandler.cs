namespace Blogger.Application.Articles.GetTaggedArticles;

public class GetTaggedArticlesQueryHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetTaggedArticlesQuery, IReadOnlyList<GetTaggedArticlesQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyList<GetTaggedArticlesQueryResponse>> Handle(GetTaggedArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetLatestArticlesAsync(request.Tag, cancellationToken);

        return articles.Select(x => (GetTaggedArticlesQueryResponse)x)
                       .ToImmutableList();
    }
}
