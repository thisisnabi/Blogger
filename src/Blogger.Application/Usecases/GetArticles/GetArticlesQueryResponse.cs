namespace Blogger.Application.Usecases.GetArticles;

public record GetArticlesQueryResponse(
    ArticleId ArticleId,
    string Title, 
    string Summery,
    DateTime PublishedOnUtc,
    int ReadOnMinutes,
    string Tags);
