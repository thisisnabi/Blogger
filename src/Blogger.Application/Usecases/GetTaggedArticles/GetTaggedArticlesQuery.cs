namespace Blogger.Application.Usecases.GetTaggedArticles;
public record GetTaggedArticlesQuery(Tag Tag) 
    : IRequest<IReadOnlyList<GetTaggedArticlesQueryResponse>>;