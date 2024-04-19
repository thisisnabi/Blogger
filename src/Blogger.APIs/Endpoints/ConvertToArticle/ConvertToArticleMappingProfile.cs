namespace Blogger.APIs.Contracts.ConvertToArticle;

public class ConvertToArticleMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<ConvertToArticleRequest, ConvertToArticleCommand>()
                   .Map(x => x.DraftId, src => ArticleId.Create(src.DraftId));
    }
}
