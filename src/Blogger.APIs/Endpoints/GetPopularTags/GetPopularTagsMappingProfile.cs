using Blogger.APIs.Endpoints.GetPopularTags;
using Blogger.Application.Usecases.GetPopularTags;

namespace Blogger.APIs.Contracts.GetPopularTags;

public class GetPopularTagsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetPopularTagsQueryResponse, GetPopularTagsResponse>()
                  .Map(x => x.Name, src => src.Tag.ToString());
    }
}
