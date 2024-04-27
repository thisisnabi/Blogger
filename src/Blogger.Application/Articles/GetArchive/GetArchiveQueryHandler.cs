namespace Blogger.Application.Articles.GetArchive;

public class GetArchiveQueryHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetArchiveQuery, IReadOnlyList<GetArchiveQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyList<GetArchiveQueryResponse>> Handle(GetArchiveQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetArchiveArticlesAsync(cancellationToken);

        return articles.GroupBy(x => new { x.PublishedOnUtc.Year, x.PublishedOnUtc.Month })
                       .Select(z => new GetArchiveQueryResponse(z.Key.Year,
                                                                z.Key.Month,
                                                                z.Select(d => (ArticleOnArchive)d).ToImmutableList()))
                       .ToImmutableList();
    }
}
