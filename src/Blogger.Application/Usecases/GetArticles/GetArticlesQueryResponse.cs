namespace Blogger.Application.Usecases.GetArticles;

public record GetArticlesQueryResponse(
    ArticleId ArticleId,
    string Title, 
    string Summary,
    DateTime PublishedOnUtc,
    int ReadOnMinutes,
    string Tags);
