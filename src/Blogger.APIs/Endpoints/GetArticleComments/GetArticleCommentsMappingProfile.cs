using Blogger.Application.Usecases.GetArticleComments;
using Blogger.Domain.ArticleAggregate;

namespace Blogger.APIs.Contracts.GetArticleComments;

public class GetArticleCommentsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetArticleCommentsRequest, GetApprovedArticleCommentsQuery>()
                   .Map(x => x.ArticleId, src => ArticleId.Create(src.ArticleId));

        config.ForType<GetArticleCommentsResponse, GetApprovedArticleCommentsQueryResponse>();
    }
}