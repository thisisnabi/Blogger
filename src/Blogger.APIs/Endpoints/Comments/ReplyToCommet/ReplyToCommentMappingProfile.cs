using Blogger.Application.Comments.ReplyToComment;
using Blogger.Domain.CommentAggregate;

namespace Blogger.APIs.Endpoints.Comments.ReplyToCommet;

public class ReplyToCommentMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<ReplyToCommentRequestModel, ReplyToCommentCommand>()
                   .Map(x => x.CommentId, src => CommentId.Create(src.CommentId))
                   .Map(x => x.Client, src => Client.Create(src.body.FullName, src.body.Email))
                   .Map(x => x.Content, src => src.body.Content);

        config.ForType<ReplyToCommentCommandResponse, ReplyToCommentResponse>()
                  .Map(x => x.ReplyId, src => src.ReplyId.ToString());
    }
}