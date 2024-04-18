using Blogger.Domain.ArticleAggregate;

namespace Blogger.Domain.CommentAggregate;

public class Comment: AggregateRootBase<CommentId>
{

    public Comment(CommentId id):base(id)
    {
        _replaies = [];
    }
    public Comment() : base(null)
    {
    }

    public Client Client { get; init; } = null!;
    public ApproveLink ApproveLink { get; init; } = null!;
    public ArticleId ArticleId{ get; init; } = null!;

    public DateTime CreatedOnUtc { get; init; }

    public string Content { get; init; } = null!;

    public bool IsApproved { get; private set; }

    private IList<Replay> _replaies;
    public IReadOnlyCollection<Replay> Replaies => _replaies.ToImmutableList();

    public static Comment Create(ArticleId articleId,  Client client, string content, ApproveLink approveLink) =>
        new Comment(CommentId.CreateUniqueId())
        {
            ArticleId = articleId,
            Content = content,
            CreatedOnUtc = DateTime.UtcNow,
            Client = client,
            IsApproved = false,
            ApproveLink = approveLink
        };

    public void Approve() => IsApproved = true;

    public Replay ReplayComment(Client client,string content, ApproveLink approveLink)
    {
        if (!IsApproved)
        {
            // TODO: // add new costum exception in Article aggregate
            throw new Exception("Invalid action in this status");
        }

        var replay = Replay.Create(client, content, approveLink);

        _replaies ??= new List<Replay>();
        _replaies.Add(replay);

        return replay;
    }
}
