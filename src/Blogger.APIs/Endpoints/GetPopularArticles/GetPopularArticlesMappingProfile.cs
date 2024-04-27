using Blogger.Application.Articles.GetPopularArticles;

namespace Blogger.APIs.Contracts.GetPopularArticles;

public class GetPopularArticlesMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetPopularArticlesQueryResponse, GetPopularArticlesResponse>()
                    .Map(x => x.ArticleId, src => src.ArticleId.ToString());
    }
}