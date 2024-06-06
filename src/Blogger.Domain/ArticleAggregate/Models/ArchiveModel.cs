namespace Blogger.Domain.ArticleAggregate.Models;

public record ArchiveModel(int Year, int Month, IEnumerable<ArticleArchiveModel> Articles);
public record ArticleArchiveModel(ArticleId ArticleId, string Title, int DayOfMonth);
