namespace Blogger.Application.Usecases.GetArticles;

internal class GetArticlesMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<IReadOnlyList<Article>?, IReadOnlyList<GetArticlesQueryResponse>>
           .NewConfig()
           .MapWith(src => MapArticleToArticleQueryResponse(src));

    }

    private IReadOnlyList<GetArticlesQueryResponse> MapArticleToArticleQueryResponse(IReadOnlyList<Article>? src)
    {
        return src.Select(x => new GetArticlesQueryResponse(
            x.Id,
            x.Title,
            x.Summary,
            x.PublishedOnUtc,
            x.GetReadOnInMinutes,
            x.Tags.ToImmutableList())).ToImmutableArray();
    }
}
