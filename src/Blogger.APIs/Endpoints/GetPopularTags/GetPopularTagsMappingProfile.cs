using Blogger.APIs.Endpoints.GetPopularTags;
using Blogger.Application.Usecases.GetPopularTags;

namespace Blogger.APIs.Contracts.GetPopularTags;

public class GetPopularTagsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetTagsQueryResponse, GetPopularTagsResponse>()
                  .Map(x => x.Tags, src => src.Tags
                                              .Select(x => x.Value));
    }
}
