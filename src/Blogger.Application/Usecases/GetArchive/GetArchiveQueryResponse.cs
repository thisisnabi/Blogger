namespace Blogger.Application.Usecases.GetArchive;

public record GetArchiveQueryResponse(int Year, int Month, IReadOnlyList<ArticleOnArchive> ArticleOnArchives);

public record ArticleOnArchive(ArticleId ArticleId, string Title, int Day);