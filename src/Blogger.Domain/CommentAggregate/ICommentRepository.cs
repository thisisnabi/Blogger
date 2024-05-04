
using Blogger.Domain.ArticleAggregate;

namespace Blogger.Domain.CommentAggregate;
public interface ICommentRepository
{
    Task<Comment?> GetCommentByApproveLinkAsync(string link, CancellationToken cancellationToken);
    Task<IReadOnlyList<Comment>> GetApprovedArticleCommentsAsync(ArticleId articleId, CancellationToken cancellationToken);
    Task<IReadOnlyList<Reply>> GetApprovedRepliesAsync(CommentId commentId, CancellationToken cancellationToken);


    Task CreateAsync(Comment comment, CancellationToken cancellationToken);

    Task<Comment?> GetCommentByIdAsync(CommentId commentId, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
