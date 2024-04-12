
namespace Blogger.Domain.ArticleAggregate;
public interface IArticleRepository
{
    Task CreateAsync(Article article, CancellationToken cancellationToken);
    Task<Article> GetArticleByCommentId(CommentId commentId, CancellationToken cancellationToken);
    Task<Article> GetArticleById(ArticleId articleId, CancellationToken cancellationToken);
    Task<IReadOnlyList<Article>> GetArticles(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<Article> GetDraftById(ArticleId articleId, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
