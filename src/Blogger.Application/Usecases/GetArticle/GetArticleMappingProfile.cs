namespace Blogger.Application.Usecases.GetArticle;

internal class GetArticleMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Article, GetArticleQueryResponse>()
                            .Map(x => x.ArticleId, src => src.Id)
                            .Map(x => x.ReadOnMinutes, src => src.ReadOn);
    }
}