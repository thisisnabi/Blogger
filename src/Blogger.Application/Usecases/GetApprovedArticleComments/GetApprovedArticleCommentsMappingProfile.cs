using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.GetApprovedArticleComments;
internal class GetApprovedArticleCommentsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<IReadOnlyList<Comment>?, IReadOnlyList<GetApprovedArticleCommentsQueryResponse>>
           .NewConfig()
           .MapWith(src => MapCommentToCommentResponse(src));
    }

    private IReadOnlyList<GetApprovedArticleCommentsQueryResponse> MapCommentToCommentResponse(IReadOnlyList<Comment>? src)
    {
        return src.Select(x => new GetApprovedArticleCommentsQueryResponse(x.Client.FullName, x.CreatedOnUtc, x.Content))
                       .ToImmutableArray();
    }
}