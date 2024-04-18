namespace Blogger.Domain.CommentAggregate;

public class ApproveLink : ValueObject<Client>
{
    public string ApproveId { get; set; } = null!;

    public DateTime ExpirationOnUtc { get; set; }

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return ApproveId;
        yield return ExpirationOnUtc;
    }

    private ApproveLink(string approvedId, DateTime expairedOn)
    {
        ApproveId = approvedId;
        ExpirationOnUtc = expairedOn;
    }

    private ApproveLink()
    {
        
    }

    public static ApproveLink Create(string approvedId, DateTime expairedOn) =>
         new ApproveLink(approvedId, expairedOn);
}
