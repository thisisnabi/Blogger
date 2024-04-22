using Blogger.Application.Usecases.GetComments;
using Blogger.Domain.ArticleAggregate;

namespace Blogger.APIs.Contracts.GetComments;

public class GetCommentsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetCommentsRequest, GetCommentsQuery>()
                   .Map(x => x.ArticleId, src => ArticleId.Create(src.ArticleId));

        config.ForType<GetCommentsResponse, GetCommentsQueryResponse>();
    }
}