using Blogger.Application.Comments.ApproveComment;

namespace Blogger.APIs.Endpoints.Comments.ApproveComment;

public class ApproveCommentMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<ApproveCommentRequest, ApproveCommentCommand>()
                   .Map(x => x.Link, src => src.Link);
    }
}
