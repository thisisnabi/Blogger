using Blogger.Application.Usecases.GetArchive;

namespace Blogger.Application.Usecases.GetArticleArchive;
public class GetArchiveMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<IGrouping<dynamic, Article>, GetArchiveQueryResponse>
           .NewConfig()
           .MapWith(src => MapArticleGroupToArticleQueryResponse(src));
    }

    private GetArchiveQueryResponse MapArticleGroupToArticleQueryResponse(IGrouping<dynamic, Article> src)
    {
        return new GetArchiveQueryResponse(src.Key.Year,
                                           src.Key.Month,
                                           src.Select(m => new ArticleOnArchive(m.Id, m.Title, m.PublishedOnUtc.Day))
                                              .ToImmutableArray());
    }
}