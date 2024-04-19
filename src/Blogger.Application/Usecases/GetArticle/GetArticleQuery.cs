namespace Blogger.Application.Usecases.GetArticle;
public record GetArticleQuery(ArticleId ArticleId) 
    : IRequest<GetArticleQueryResponse>;