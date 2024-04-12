using System.Collections.Immutable;
using System.Linq;

namespace Blogger.Application.Usecases.GetArticles;

public class GetArticlesQueryHandler(IArticleRepository articleRepository) 
    : IRequestHandler<GetArticlesQuery, IReadOnlyList<GetArticlesQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyList<GetArticlesQueryResponse>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetArticles(request.PageNumber, request.PageSize, cancellationToken);

        return articles.Select(x => new GetArticlesQueryResponse(
            x.Id,
            x.Title,
            x.Summery,
            x.PublishedOnUtc,
            x.GetReadOnInMinutes,
            string.Join(",", x.Tags)
            )).ToImmutableArray();
    }
}
