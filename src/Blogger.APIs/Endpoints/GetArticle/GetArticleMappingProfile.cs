using Blogger.Application.Usecases.GetArticle;

namespace Blogger.APIs.Contracts.GetArticle;

public class GetArticleMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetArticleRequest, GetArticleQuery>()
                   .Map(x => x.ArticleId, src => ArticleId.Create(src.ArticleId));

        // TODO: Map and implement response
        config.ForType<GetArticleQueryResponse, GetArticleResponse>();
    }
}
