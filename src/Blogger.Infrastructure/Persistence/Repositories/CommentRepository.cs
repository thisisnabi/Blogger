using Blogger.Domain.CommentAggregate;

namespace Blogger.Infrastructure.Persistence.Repositories;
internal class CommentRepository : ICommentRepository
{
    public Task CreateAsync(Comment comment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> GetCommentByApprovedLinkAsync(ApproveLink approveLink, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> GetCommentByIdAsync(CommentId commentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
