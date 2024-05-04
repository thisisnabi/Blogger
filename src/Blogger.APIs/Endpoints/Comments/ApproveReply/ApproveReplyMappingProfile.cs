using Blogger.Application.Comments.ApproveReply;
using Blogger.Domain.CommentAggregate;

namespace Blogger.APIs.Endpoints.Comments.ApproveReply;

public class ApproveReplyMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<ApproveReplyRequest, ApproveReplyCommand>()
                   .Map(x => x.CommentId, src => CommentId.Create(src.CommentId))
                   .Map(x => x.Link, src => src.Link);
    }
}
