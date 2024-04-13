namespace Blogger.Domain.ArticleAggregate;

public class CommentReplay(CommentReplayId id) : EntityBase<CommentReplayId>(id)
{
    public Client Client { get; init; } = null!;

    public DateTime CreatedOnUtc { get; init; }

    public string Content { get; init; } = null!;

    public bool IsApproved { get; private set; }

    public static CommentReplay Create(Client client, string content) =>
        new CommentReplay(CommentReplayId.CreateUniqueId())
        {
            Content = content,
            CreatedOnUtc = DateTime.UtcNow,
            Client = client,
            IsApproved = false
        };

    public void Approve() => IsApproved = true;
}
