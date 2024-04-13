namespace Blogger.Application.Usecases.GetArticle;

public record GetArticleQueryResponse(
    ArticleId ArticleId,
    string Title, 
    string Body,
    string Summary,
    int ReadOnMinutes,
    Author Author,
    DateTime PublishedOnUtc,
    IReadOnlyCollection<Tag> Tags);
