using Blogger.Application.Usecases.GetApprovedArticleComments;
using Blogger.Application.Usecases.GetArchive;
using Blogger.Application.Usecases.GetArticles;
using Blogger.Domain.CommentAggregate;

namespace Blogger.Application;

internal class MappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<IReadOnlyList<Comment>?, IReadOnlyList<GetApprovedArticleCommentsResponse>>
           .NewConfig()
           .MapWith(src => MapCommentToCommentResponse(src));

        TypeAdapterConfig<IReadOnlyList<Article>?, IReadOnlyList<GetArticlesQueryResponse>>
           .NewConfig()
           .MapWith(src => MapArticleToArticleQueryResponse(src));

    }


    private IReadOnlyList<GetApprovedArticleCommentsResponse> MapCommentToCommentResponse(IReadOnlyList<Comment>? src)
    {
        return src.Select(x => new GetApprovedArticleCommentsResponse(x.Client.FullName, x.CreatedOnUtc, x.Content))
                       .ToImmutableArray();
    }
    private IReadOnlyList<GetArticlesQueryResponse> MapArticleToArticleQueryResponse(IReadOnlyList<Article>? src)
    {
        return src.Select(x => new GetArticlesQueryResponse(
            x.Id,
            x.Title,
            x.Summary,
            x.PublishedOnUtc,
            x.GetReadOnInMinutes,
            string.Join(",", x.Tags)
            )).ToImmutableArray();
    }
}
