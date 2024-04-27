using Blogger.Application.Comments.MakeComment;
using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;

namespace Blogger.APIs.Endpoints.Comments.MakeComment;

public class MakeCommentMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<MakeCommetRequest, MakeCommentCommand>()
                   .Map(x => x.ArticleId, src => ArticleId.Create(src.ArticleId))
                   .Map(x => x.Client, src => Client.Create(src.FullName, src.Email))
                   .Map(x => x.Content, src => src.Content);

        config.ForType<MakeCommentCommandResponse, MakeCommentResponse>()
                  .Map(x => x.CommentId, src => src.CommentId.ToString());
    }
}