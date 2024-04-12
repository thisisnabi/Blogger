namespace Blogger.Application.Usecases.GetArticle;
public record GetArticleQuery(ArticleId articleId) 
    : IRequest<GetArticleQueryResponse>;