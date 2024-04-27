namespace Blogger.Application.Articles.GetPopularTags;

public class GetPopularTagsQueryHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetPopularTagsQuery, IReadOnlyList<GetPopularTagsQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyList<GetPopularTagsQueryResponse>>
        Handle(GetPopularTagsQuery request, CancellationToken cancellationToken)
    {
        var tags = await _articleRepository.GetPopularTagsAsync(request.Size, cancellationToken);
        return tags.Select(x => new GetPopularTagsQueryResponse(x))
                   .ToImmutableList();
    }
}
