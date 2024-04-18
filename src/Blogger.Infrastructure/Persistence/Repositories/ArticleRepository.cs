using Blogger.Domain.ArticleAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Blogger.Infrastructure.Persistence.Repositories;
internal class ArticleRepository(BloggerDbContext bloggerDbContext) : IArticleRepository
{
    public async Task CreateAsync(Article article, CancellationToken cancellationToken)
    {
        await bloggerDbContext.Articles.AddAsync(article, cancellationToken);
    }

    public async Task<IReadOnlyList<Article>> GetArchiveArticlesAsync(CancellationToken cancellationToken)
    {
        var que = await bloggerDbContext.Articles.Where(x => x.Status == ArticleStatus.Published)
                                           .ToListAsync(cancellationToken);

        return que.ToImmutableList();
    }

    public Task<Article?> GetArticleByIdAsync(ArticleId articleId, CancellationToken cancellationToken)
    {
        return bloggerDbContext.Articles
                                    .Where(x => x.Status == ArticleStatus.Published)
                                    .FirstOrDefaultAsync(x => x.Id == articleId, cancellationToken);
    }

    public Task<Article?> GetDraftByIdAsync(ArticleId articleId, CancellationToken cancellationToken)
    {
        return bloggerDbContext.Articles
                                    .Where(x => x.Status == ArticleStatus.Draft)
                                    .FirstOrDefaultAsync(x => x.Id == articleId, cancellationToken);
    }

    public async Task<IReadOnlyList<Article>> GetLatestArticlesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var que = await bloggerDbContext.Articles.ToListAsync(cancellationToken);

        return que.ToImmutableList();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await bloggerDbContext.SaveChangesAsync(cancellationToken);
    }
}
