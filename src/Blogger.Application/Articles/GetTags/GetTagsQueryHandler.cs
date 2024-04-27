namespace Blogger.Application.Articles.GetTags;

public class GetTagsQueryHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetTagsQuery, IReadOnlyList<GetTagsQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyList<GetTagsQueryResponse>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
    {
        var tags = await _articleRepository.GetTagsAsync(cancellationToken);

        return tags.GroupBy(x => x)
                   .Select(x => new GetTagsQueryResponse(x.Key, x.Count()))
                   .ToImmutableList();
    }
}
