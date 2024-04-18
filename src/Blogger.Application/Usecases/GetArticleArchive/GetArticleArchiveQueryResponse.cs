namespace Blogger.Application.Usecases.GetArticleArchive;

public record GetArticleArchiveQueryResponse(int Year, int Month, IReadOnlyList<ArticleOnArchive> ArticleOnArchives);

public record ArticleOnArchive(ArticleId ArticleId, string Title, int Day);