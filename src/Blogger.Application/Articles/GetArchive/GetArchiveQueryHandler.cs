using System.Linq;

namespace Blogger.Application.Articles.GetArchive;

public class GetArchiveQueryHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetArchiveQuery, IReadOnlyCollection<GetArchiveQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyCollection<GetArchiveQueryResponse>> Handle(GetArchiveQuery request, CancellationToken cancellationToken)
    {
        var archives = await _articleRepository.GetArchivesAsync(cancellationToken);

        var results = archives.Select(x => new GetArchiveQueryResponse(
            x.Year, x.Month, 
            [.. x.Articles.Select(d => new ArticleArchiveResponse(d.ArticleId, d.Title, d.DayOfMonth))]))
            .ToList();

        return [.. results];
    }
}
