using Blogger.Application.Articles.GetArticles;

namespace Blogger.APIs.Endpoints.Articles.GetArticles;

public class GetArticlesMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetArticlesRequest, GetArticlesQuery>()
                   .Map(x => x.PageNumber, src => src.Page)
                   .Map(x => x.PageSize, src => src.Size);

        config.ForType<GetArticlesQueryResponse, GetArticlesResponse>()
                    .Map(x => x.ArticleId, src => src.ArticleId.ToString())
                    .Map(x => x.Tags, src => src.Tags.Select(x => x.Value)
                                                     .ToImmutableArray());
    }
}