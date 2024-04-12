namespace Blogger.Application.Usecases.GetArticleArchive;

public class GetArticlesQueryHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetArticleArchiveQuery, IReadOnlyList<GetArticleArchiveQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyList<GetArticleArchiveQueryResponse>> Handle(GetArticleArchiveQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetArchiveArticlesAsync(cancellationToken);

        // TODO: using mapster for mapping 
        var groupedArticles = articles.GroupBy(x => new { x.PublishedOnUtc.Year , x.PublishedOnUtc.Month})
                                      .Select(z => new GetArticleArchiveQueryResponse(z.Key.Year, z.Key.Month,
                                              z.Select(m => new ArticleOnArchive(m.Id,m.Title,m.PublishedOnUtc.Day)).ToImmutableArray()))
                                      .ToImmutableArray();

        return groupedArticles;
    }
}
