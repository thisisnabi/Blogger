namespace Blogger.APIs.Contracts.GetTaggedArticles;

public record GetTaggedArticlesResponse(
    string ArticleId,
    string Title,
    string Body,
    string Summary,
    DateTime PublishedOnUtc,
    int ReadOnMinutes,
    string[] Tags);