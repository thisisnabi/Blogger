using Blogger.Application.Articles.MakeDraft;
using Blogger.Domain.ArticleAggregate;

namespace Blogger.APIs.Endpoints.Articles.MakeDraft;

public class MakeDraftMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<MakeDraftRequest, MakeDraftCommand>()

                   .Map(x => x.Tags, src => src.Tags.Select(x => Tag.Create(x))
                                                    .ToImmutableList());

        config.ForType<MakeDraftCommandResponse, MakeDraftResponse>()
                  .Map(x => x.DraftId, src => src.DraftId.Slug);
    }
}
