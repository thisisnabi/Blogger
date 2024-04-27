using Blogger.Application.Articles.GetArchive;

namespace Blogger.APIs.Endpoints.Articles.GetArchive;

public class GetArchiveMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetArchiveQueryResponse, GetArchiveResponse>()
                    .Map(x => x.Articles, src => src.Articles);

        config.ForType<ArticleOnArchive, GetArchiveItemResponse>()
                    .Map(x => x.ArticleId, src => src.ArticleId.ToString())
                    .Map(x => x.Title, src => src.Title)
                    .Map(x => x.Day, src => src.Day);

    }

}