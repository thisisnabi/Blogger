using System.Xml.Linq;

namespace Blogger.Domain.ArticleAggregate;

public class Comment(CommentId id) : EntityBase<CommentId>(id)
{
    public Client Client { get; init; } = null!;

    public DateTime CreatedOnUtc { get; init; }

    public string Content { get; init; } = null!;

    public bool IsApproved { get; private set; }

    private IList<CommentReplay> _comments = null!;
    public IReadOnlyCollection<CommentReplay> Comments => _comments.ToImmutableList();

    public static Comment Create(Client client, string content) =>
        new Comment(CommentId.CreateUniqueId())
        {
            Content = content,
            CreatedOnUtc = DateTime.UtcNow,
            Client = client,
            IsApproved = false
        };

    public void Approve() => IsApproved = true;

    public void Replay(CommentReplay commentReplay)
    {
        if (!IsApproved)
        {
            // TODO: // add new costum exception in Article aggregate
            throw new Exception("Invalid action in this status");
        }

        _comments ??= new List<CommentReplay>();
        _comments.Add(commentReplay);
    }
}
