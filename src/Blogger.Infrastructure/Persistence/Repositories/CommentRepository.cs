 namespace Blogger.Infrastructure.Persistence.Repositories;

internal class CommentRepository(BloggerDbContext bloggerDbContext) : ICommentRepository
{
    public Task<Comment?> GetCommentByApproveLinkAsync(string link, CancellationToken cancellationToken)
    {
        return bloggerDbContext.Comments.FirstOrDefaultAsync(x => x.ApproveLink.ApproveId == link, cancellationToken);
    }

    public async Task<IReadOnlyList<Comment>> GetApprovedArticleCommentsAsync(ArticleId articleId, CancellationToken cancellationToken)
    {
        var que = await bloggerDbContext.Comments.Where(x => x.ArticleId.Slug == articleId.Slug)
                                                 .Where(c => c.IsApproved)
                                                 .ToListAsync(cancellationToken);

        return que.ToImmutableList();
    }
     
    public async Task<IReadOnlyList<Reply>> GetApprovedRepliesAsync(CommentId commentId, CancellationToken cancellationToken)
    {
        var comment = await bloggerDbContext.Comments.FirstAsync(x => x.IsApproved && x.Id == commentId, cancellationToken);

        return comment.Replies.ToImmutableList();
    }


    public async Task CreateAsync(Comment comment, CancellationToken cancellationToken)
    {
        await bloggerDbContext.Comments.AddAsync(comment, cancellationToken);
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
