using Blogger.Application.Usecases.ReplayToComment;
using Blogger.Domain.CommentAggregate;

namespace Blogger.APIs.Contracts.ReplayToCommet;

public class ReplayToCommentMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<ReplayToCommentRequestModel, ReplayToCommentCommand>()
                   .Map(x => x.CommentId, src => CommentId.Create(src.CommentId))
                   .Map(x => x.Client, src => Client.Create(src.body.FullName, src.body.Email))
                   .Map(x => x.Content, src => src.body.Content);

        config.ForType<ReplayToCommentCommandResponse, ReplayToCommentResponse>()
                  .Map(x => x.ReplayId, src => src.ReplayId.ToString());
    }
}