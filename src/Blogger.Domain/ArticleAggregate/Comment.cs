using Blogger.Domain.ClientAggregate;

namespace Blogger.Domain.ArticleAggregate;

public class Comment(CommentId id) : EntityBase<CommentId>(id)
{
    public ClientId ClientId { get; init; }

    public DateTime CreatedOnUtc { get; set; }

    public string Content { get; set; }

    public bool IsApproved { get; set; }

    public static Comment Create(ClientId clientId, string content) =>
        new Comment(CommentId.CreateUniqueId())
        {
            Content = content,
            CreatedOnUtc = DateTime.UtcNow,
            ClientId = clientId,
            IsApproved = false
        };
}
