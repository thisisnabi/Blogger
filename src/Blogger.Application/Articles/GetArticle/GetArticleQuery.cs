namespace Blogger.Application.Articles.GetArticle;
public record GetArticleQuery(ArticleId ArticleId)
    : IRequest<GetArticleQueryResponse>;