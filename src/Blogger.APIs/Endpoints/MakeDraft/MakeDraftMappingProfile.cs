using Blogger.Application.Usecases.MakeDraft;
using Blogger.Domain.ArticleAggregate;

namespace Blogger.APIs.Contracts.MakeDraft;

public class MakeCommentMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<MakeCommentRequest, MakeDraftCommand>()
                   .Map(x => x.Tags, src => src.Tags.Select(x => Tag.Create(x))
                                                    .ToImmutableList());

        config.ForType<MakeDraftCommandResponse, MakeCommentResponse>()
                  .Map(x => x.DraftId, src => src.DraftId.Slug);
    }
}
