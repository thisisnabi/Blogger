using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;

namespace Blogger.Infrastructure.Persistence.Repositories;
internal class ArticleRepository : IArticleRepository
{
    public Task CreateAsync(Article article, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Comment>> GetApprovedArticleCommentsAsync(ArticleId articleId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Article>> GetArchiveArticlesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Article> GetArticleByCommentIdAsync(CommentId commentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Article> GetArticleByIdAsync(ArticleId articleId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Article> GetDraftByIdAsync(ArticleId articleId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Article>> GetLatestArticlesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
