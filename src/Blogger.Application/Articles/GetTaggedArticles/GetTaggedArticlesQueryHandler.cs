namespace Blogger.Application.Articles.GetTaggedArticles;

public class GetTaggedArticlesQueryHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetTaggedArticlesQuery, IReadOnlyCollection<GetTaggedArticlesQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyCollection<GetTaggedArticlesQueryResponse>> Handle(GetTaggedArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetLatestArticlesAsync(request.Tag, cancellationToken);

        return [.. articles.Select(x => (GetTaggedArticlesQueryResponse)x)];
    }
}
