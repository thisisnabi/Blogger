namespace Blogger.APIs.Contracts.GetArticles;

public record GetArticlesResponse(
    string ArticleId,
    string Title,
    string Body,
    string Summary,
    DateTime PublishedOnUtc,
    int ReadOnMinutes,
    string[] Tags);