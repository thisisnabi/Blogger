namespace Blogger.APIs.Contracts.GetPopularTags;

public class GetPopularTagsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetPopularTagsQueryResponse, GetPopularTagsResponse>()
                  .Map(x => x.Tags, src => src.Tags
                                              .Select(x => x.Value));
    }
}
