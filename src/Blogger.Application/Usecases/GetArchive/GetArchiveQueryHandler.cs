namespace Blogger.Application.Usecases.GetArchive;

public class GetArchiveQueryHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetArchiveQuery, IReadOnlyList<GetArchiveQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyList<GetArchiveQueryResponse>> Handle(GetArchiveQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetArchiveArticlesAsync(cancellationToken);

        var groupedArticles = articles.GroupBy(x => new { x.PublishedOnUtc.Year, x.PublishedOnUtc.Month })
                                      .Select(z => z.Adapt<GetArchiveQueryResponse>())
                                      .ToImmutableArray();

        return groupedArticles;
    }
}
