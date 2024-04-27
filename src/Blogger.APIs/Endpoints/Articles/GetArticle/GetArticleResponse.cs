namespace Blogger.APIs.Endpoints.Articles.GetArticle;

public record GetArticleResponse(string ArticleId,
    string Title,
    string Body,
    string Summary,
    int ReadOnMinutes,
    string AuthorFullName,
    string AuthorAvatar,
    string AuthorJobTitle,
    DateTime PublishedOnUtc,
    string[] Tags);