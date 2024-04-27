namespace Blogger.APIs.Endpoints.Articles.GetArticles;

public record GetArticlesResponse(
    string ArticleId,
    string Title,
    string Body,
    string Summary,
    DateTime PublishedOnUtc,
    int ReadOnMinutes,
    string[] Tags);