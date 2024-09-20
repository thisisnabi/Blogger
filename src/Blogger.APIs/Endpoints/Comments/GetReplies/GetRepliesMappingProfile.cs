namespace Blogger.APIs.Endpoints.Comments.GetReplies;

public class GetRepliesMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetRepliesRequest, GetRepliesQuery>()
                   .Map(x => x.CommentId, src => CommentId.Create(src.CommentId));

        config.ForType<GetRepliesResponse, GetRepliesQueryResponse>();
    }
}