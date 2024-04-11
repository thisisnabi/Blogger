using Blogger.Domain.UserAggregate;

namespace Blogger.Domain.ArticleAggregate;

public class Comment(CommentId id) : EntityBase<CommentId>(id)
{
    public UserId UserId { get; init; }

    public DateTime CreatedOnUtc { get; set; }

    public string Content { get; set; }

    public bool IsApproved { get; set; }

    public static Comment Create(UserId userId, string content) =>
        new Comment(CommentId.CreateUniqueId())
        {
            Content = content,
            CreatedOnUtc = DateTime.UtcNow,
            UserId = userId,
            IsApproved = false
        };
}
