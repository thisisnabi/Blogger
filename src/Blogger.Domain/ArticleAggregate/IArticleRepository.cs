
namespace Blogger.Domain.ArticleAggregate;
public interface IArticleRepository
{
    Task CreateAsync(Article article, CancellationToken cancellationToken);
    Article GetDraftById(ArticleId articleId);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
