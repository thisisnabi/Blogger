using Blogger.Application.Articles.GetPopularTags;

namespace Blogger.APIs.Endpoints.Articles.GetPopularTags;

public class GetPopularTagsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetPopularTagsQueryResponse, GetPopularTagsResponse>()
                  .Map(x => x.Name, src => src.Tag.ToString());
    }
}
