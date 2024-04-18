
using Blogger.Domain.CommentAggregate;

namespace Blogger.Domain.ArticleAggregate;
public interface IArticleRepository
{
    Task CreateAsync(Article article, CancellationToken cancellationToken);
    Task<IReadOnlyList<Comment>> GetApprovedArticleCommentsAsync(ArticleId articleId, CancellationToken cancellationToken);
    Task<IReadOnlyList<Article>> GetArchiveArticlesAsync(CancellationToken cancellationToken);
    Task<Article> GetArticleByCommentIdAsync(CommentId commentId, CancellationToken cancellationToken);
    Task<Article> GetArticleByIdAsync(ArticleId articleId, CancellationToken cancellationToken);
    Task<Article> GetDraftByIdAsync(ArticleId articleId, CancellationToken cancellationToken);
    Task<IReadOnlyList<Article>> GetLatestArticlesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
