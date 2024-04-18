using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Blogger.Infrastructure.Persistence.Repositories;
internal class CommentRepository(BloggerDbContext bloggerDbContext) : ICommentRepository
{
    public async Task CreateAsync(Comment comment, CancellationToken cancellationToken)
    {
        await bloggerDbContext.Comments.AddAsync(comment, cancellationToken);
    }

    public async Task<IReadOnlyList<Comment>> GetApprovedArticleCommentsAsync(ArticleId articleId, CancellationToken cancellationToken)
    {
       var que = await bloggerDbContext.Comments.Where(x => x.ArticleId == articleId)
                                                .Where(c => c.IsApproved)
                                                .ToListAsync(cancellationToken);

        return que.ToImmutableList();
    }

    public Task<Comment?> GetCommentByApprovedLinkAsync(ApproveLink approveLink, CancellationToken cancellationToken)
    {
        return bloggerDbContext.Comments.FirstOrDefaultAsync(x => x.ApproveLink == approveLink, cancellationToken);
    }

    public Task<Comment?> GetCommentByIdAsync(CommentId commentId, CancellationToken cancellationToken)
    {
        return bloggerDbContext.Comments.FirstOrDefaultAsync(x => x.Id == commentId, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await bloggerDbContext.SaveChangesAsync(cancellationToken);
    }
}
