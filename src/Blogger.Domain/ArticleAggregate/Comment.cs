using Blogger.Domain.UserAggregate;

namespace Blogger.Domain.ArticleAggregate;

public class Comment(CommentId id) : EntityBase<CommentId>(id)
{
    public UserId UserId { get; init; }


}
