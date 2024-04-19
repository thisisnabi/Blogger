namespace Blogger.Application.Usecases.GetPopularTags;

public class GetPopularTagsQueryHandler(IArticleRepository articleRepository) : IRequestHandler<GetPopularTagsQuery, GetPopularTagsQueryResponse>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<GetPopularTagsQueryResponse> Handle(GetPopularTagsQuery request, CancellationToken cancellationToken)
    {
        var tags = await _articleRepository.GetPopularTagsAsync(request.Size,cancellationToken);
        return new  GetPopularTagsQueryResponse(tags);
    }
}
