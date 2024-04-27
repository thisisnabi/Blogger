using Blogger.Application.Articles.GetArticle;
using Blogger.Domain.ArticleAggregate;

namespace Blogger.APIs.Endpoints.Articles.GetArticle;

public class GetArticleMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetArticleRequest, GetArticleQuery>()
                   .Map(x => x.ArticleId, src => ArticleId.Create(src.ArticleId));

        config.ForType<GetArticleQueryResponse, GetArticleResponse>()
                    .Map(x => x.ArticleId, src => src.ArticleId.ToString())
                    .Map(x => x.AuthorFullName, src => src.Author.FullName)
                    .Map(x => x.AuthorAvatar, src => src.Author.Avatar)
                    .Map(x => x.AuthorJobTitle, src => src.Author.JobTitle)
                    .Map(x => x.Tags, src => src.Tags.Select(x => x.Value)
                                                     .ToImmutableArray());
    }
}