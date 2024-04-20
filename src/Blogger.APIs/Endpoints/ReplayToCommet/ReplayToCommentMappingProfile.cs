using Blogger.Application.Usecases.ReplayToComment;
using Blogger.Domain.CommentAggregate;

namespace Blogger.APIs.Contracts.ReplayToCommet;

public class ReplayToCommentMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<ReplayToCommentRequest, ReplayToCommentCommand>()
                   .Map(x => x.CommentId, src => CommentId.Create(src.CommentId))
                   .Map(x => x.Client, src => Client.Create(src.FullName, src.Email))
                   .Map(x => x.Content, src => src.Content);

        config.ForType<ReplayToCommentCommandResponse, ReplayToCommentResponse>()
                  .Map(x => x.ReplayId, src => src.ReplayId.ToString());
    }
}