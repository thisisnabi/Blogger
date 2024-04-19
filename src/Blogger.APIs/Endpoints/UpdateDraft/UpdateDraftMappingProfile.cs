namespace Blogger.APIs.Contracts.UpdateDraft;

public class UpdateDraftMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<UpdateDraftRequest, UpdateDraftCommand>()
                   .Map(x => x.DraftId, src => ArticleId.Create(src.DraftId))
                   .Map(x => x.Tags, src => src.Tags.Select(x => Tag.Create(x))
                                                    .ToImmutableList());
    }
}
