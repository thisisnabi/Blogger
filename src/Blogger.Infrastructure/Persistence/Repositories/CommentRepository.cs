﻿using Blogger.BuildingBlocks.Domain;

namespace Blogger.Infrastructure.Persistence.Repositories;

public class CommentRepository(BloggerDbContext bloggerDbContext) : ICommentRepository
{
    public IUnitOfWork UnitOfWork => bloggerDbContext;

    public Task<Comment?> GetCommentByApproveLinkAsync(string link, CancellationToken cancellationToken)
    {
        return bloggerDbContext.Comments.FirstOrDefaultAsync(x => x.ApproveLink.ApproveId == link, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Comment>> GetApprovedArticleCommentsAsync(ArticleId articleId, CancellationToken cancellationToken)
    {
        var que = await bloggerDbContext.Comments.Where(x => x.ArticleId.Slug == articleId.Slug)
                                                 .Where(c => c.IsApproved)
                                                 .ToListAsync(cancellationToken);

        return que.ToImmutableList();
    }
     
    public async Task<IReadOnlyCollection<Reply>> GetApprovedRepliesAsync(CommentId commentId, CancellationToken cancellationToken)
    {
        var replies = await bloggerDbContext.Comments
                                             .AsNoTracking()
                                             .Where(x => x.IsApproved && x.Id == commentId)
                                             .SelectMany(x => x.Replies.Where(x => x.IsApproved))
                                             .ToListAsync(cancellationToken);
        return [.. replies];
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
