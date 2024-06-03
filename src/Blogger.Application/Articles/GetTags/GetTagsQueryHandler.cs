namespace Blogger.Application.Articles.GetTags;

public class GetTagsQueryHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetTagsQuery, IReadOnlyCollection<GetTagsQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyCollection<GetTagsQueryResponse>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
    {
        var tags = await _articleRepository.GetTagsAsync(cancellationToken);

        return [.. tags.Select(x => new GetTagsQueryResponse(x.Tag, x.Count))];
    }
}
