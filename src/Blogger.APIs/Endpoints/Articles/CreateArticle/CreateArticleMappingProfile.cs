namespace Blogger.APIs.Endpoints.Articles.CreateArticle;

public class CreateArticleMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateArticleRequest, CreateArticleCommand>()
                   .Map(x => x.Tags, src => src.Tags.Select(x => Tag.Create(x))
                                                    .ToImmutableList());

        config.ForType<CreateArticleCommandResponse, CreateArticleResponse>()
                  .Map(x => x.ArticleId, src => src.ArticleId.Slug);
    }
}
