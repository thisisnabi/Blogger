namespace Blogger.Domain.CommentAggregate;

public class Replay(ReplayId id) : EntityBase<ReplayId>(id)
{
    public Client Client { get; init; } = null!;
    public ApproveLink ApproveLink { get; init; } = null!;
    public DateTime CreatedOnUtc { get; init; }

    public string Content { get; init; } = null!;

    public bool IsApproved { get; private set; }

    public static Replay Create(Client client, string content, ApproveLink approveLink) =>
        new Replay(ReplayId.CreateUniqueId())
        {
            Content = content,
            CreatedOnUtc = DateTime.UtcNow,
            Client = client,
            IsApproved = false,
            ApproveLink = approveLink
        };

    public void Approve() => IsApproved = true;
}
