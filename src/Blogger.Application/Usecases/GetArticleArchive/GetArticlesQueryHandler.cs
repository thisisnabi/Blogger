
namespace Blogger.Application.Usecases.GetArticleArchive;

public class GetArticlesQueryHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetArticleArchiveQuery, IReadOnlyList<GetArticleArchiveQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyList<GetArticleArchiveQueryResponse>> Handle(GetArticleArchiveQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetArchiveArticlesAsync(cancellationToken);

        var groupedArticles = articles.GroupBy(x => new { x.PublishedOnUtc.Value.Year, x.PublishedOnUtc.Value.Month })
                                      .Select(z => z.Adapt<GetArticleArchiveQueryResponse>())
                                      .ToImmutableArray();

        return groupedArticles;
    }
}
