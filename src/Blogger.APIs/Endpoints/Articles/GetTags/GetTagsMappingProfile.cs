using Blogger.Application.Articles.GetTags;

namespace Blogger.APIs.Endpoints.Articles.GetTags;

public class GetTagsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetTagsQueryResponse, GetTagsResponse>()
                  .Map(x => x.Count, src => src.Count)
                  .Map(x => x.Name, src => src.Tag.ToString());
    }
}
