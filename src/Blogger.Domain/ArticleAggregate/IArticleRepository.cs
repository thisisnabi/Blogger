
namespace Blogger.Domain.ArticleAggregate;
public interface IArticleRepository
{
    Task CreateAsync(Article article, CancellationToken cancellationToken);
    Task<Article> GetArticleById(ArticleId articleId);
    Task<Article> GetDraftById(ArticleId articleId);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
