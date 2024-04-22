using Blogger.Application.Usecases.GetReplaies;
using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;

namespace Blogger.APIs.Contracts.GetReplaies;

public class GetReplaiesMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetReplaiesRequest, GetReplaiesQuery>()
                   .Map(x => x.CommentId, src => CommentId.Create(src.CommentId));

        config.ForType<GetReplaiesResponse, GetReplaiesQueryResponse>();
    }
}