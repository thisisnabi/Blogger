namespace Blogger.Application.Articles.GetArchive;

public record GetArchiveQueryResponse(int Year, int Month, IReadOnlyCollection<ArticleArchiveResponse> Articles);

public record ArticleArchiveResponse(ArticleId ArticleId, string Title, int Day);