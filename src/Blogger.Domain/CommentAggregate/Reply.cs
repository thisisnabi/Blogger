namespace Blogger.Domain.CommentAggregate;

public class Reply(ReplyId id) : EntityBase<ReplyId>(id)
{
    public Reply() : this(null!)
    {

    }

    public Client Client { get; init; } = null!;
    public ApproveLink ApproveLink { get; init; } = null!;
    public DateTime CreatedOnUtc { get; init; }

    public string Content { get; init; } = null!;

    public bool IsApproved { get; private set; }

    public static Reply Create(Client client, string content, ApproveLink approveLink) =>
        new Reply(ReplyId.CreateUniqueId())
        {
            Content = content,
            CreatedOnUtc = DateTime.UtcNow,
            Client = client,
            IsApproved = false,
            ApproveLink = approveLink
        };

    public void Approve() => IsApproved = true;
}
