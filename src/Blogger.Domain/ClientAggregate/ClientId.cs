namespace Blogger.Domain.ClientAggregate;

public class ClientId : ValueObject<ClientId>
{
    public Guid Value { get; set; }

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return Value;
    }

    private ClientId(Guid id)
    {
        Value = id;
    }

    public static ClientId CreateUniqueId() => new(Guid.NewGuid());

}
