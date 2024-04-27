using Blogger.Application.Comments.ApproveReplay;
using Blogger.Domain.CommentAggregate;

namespace Blogger.APIs.Contracts.ApproveReplay;

public class ApproveReplayMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<ApproveReplayRequest, ApproveReplayCommand>()
                   .Map(x => x.CommentId, src => CommentId.Create(src.CommentId))
                   .Map(x => x.Link, src => src.Link);
    }
}
