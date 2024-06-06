using Blogger.Domain.ArticleAggregate;

namespace Blogger.Domain.CommentAggregate;

public class Comment : AggregateRoot<CommentId>
{
    private Comment(CommentId id) : base(id)
    {
        _replies = [];
    }

    private Comment() : this(null!) { }

    private readonly IList<Reply> _replies;
    public IReadOnlyCollection<Reply> Replies => [.. _replies];

    public Client Client { get; init; } = null!;

    public ApproveLink ApproveLink { get; init; } = null!;

    public ArticleId ArticleId { get; init; } = null!;

    public DateTime CreatedOnUtc { get; init; }

    public string Content { get; init; } = null!;

    public bool IsApproved { get; private set; }

    public static Comment Create(ArticleId articleId, Client client, string content, ApproveLink approveLink)
    {
        return new Comment(CommentId.CreateUniqueId())
        {
            ArticleId = articleId,
            Content = content,
            CreatedOnUtc = DateTime.UtcNow,
            Client = client,
            IsApproved = false,
            ApproveLink = approveLink
        };
    }

    public void Approve() => IsApproved = true;

    public Reply ReplyComment(Client client, string content, ApproveLink approveLink)
    {
        if (!IsApproved)
        {
            throw new UnapprovedCommentException();
        }

        var reply = Reply.Create(client, content, approveLink);
        _replies.Add(reply);

        return reply;
    }

    public ReplyId ApproveReply(string link)
    {
        var reply = _replies.FirstOrDefault(x => x.ApproveLink.ApproveId == link);
        if (reply is null)
        {
            throw new InvalidReplyApprovalLinkException();
        }

        reply.Approve();

        return reply.Id;
    }
}
