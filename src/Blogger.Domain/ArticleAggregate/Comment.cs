namespace Blogger.Domain.ArticleAggregate;

public class Comment(CommentId id) : EntityBase<CommentId>(id)
{
    public Client Client { get; init; } = null!;

    public DateTime CreatedOnUtc { get; init; }

    public string Content { get; init; } = null!;

    public bool IsApproved { get; private set; }

    public static Comment Create(Client client, string content) =>
        new Comment(CommentId.CreateUniqueId())
        {
            Content = content,
            CreatedOnUtc = DateTime.UtcNow,
            Client = client,
            IsApproved = false
        };

    public void Approve() => IsApproved = true;
}
