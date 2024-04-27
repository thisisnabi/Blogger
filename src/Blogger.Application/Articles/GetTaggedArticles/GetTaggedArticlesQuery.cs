namespace Blogger.Application.Articles.GetTaggedArticles;
public record GetTaggedArticlesQuery(Tag Tag)
    : IRequest<IReadOnlyList<GetTaggedArticlesQueryResponse>>;