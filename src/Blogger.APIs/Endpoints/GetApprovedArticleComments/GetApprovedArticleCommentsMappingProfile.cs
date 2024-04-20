namespace Blogger.APIs.Contracts.GetApprovedArticleComments;

public class GetApprovedArticleCommentsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetApprovedArticleCommentsRequest, GetArticleCommentsQuery>()
                   .Map(x => x.ArticleId, src => ArticleId.Create(src.ArticleId));

        config.ForType<GetArticleQueryResponse, GetApprovedArticleCommentsResponse>()
                    .Map(x => x.ArticleId, src => src.ArticleId.Slug)
                    .Map(x => x.AuthorFullName, src => src.Author.FullName)
                    .Map(x => x.AuthorAvatar, src => src.Author.Avatar)
                    .Map(x => x.AuthorJobTitle, src => src.Author.JobTitle)
                    .Map(x => x.Tags, src => src.Tags.Select(x => x.Value)
                                                     .ToImmutableArray());
    }
}