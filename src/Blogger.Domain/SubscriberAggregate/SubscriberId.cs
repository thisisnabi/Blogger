using Blogger.Domain.Common.Exceptions;

namespace Blogger.Domain.SubscriberAggregate;

public class SubscriberId : ValueObject<SubscriberId>
{
    public MailAddress Email { get; init; } = null!;

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return Email;
    }

    public static SubscriberId CreateUniqueId(string email)
    {
        return Create(email);
    }

    public static SubscriberId Create(string value)
    {

        if (MailAddress.TryCreate(value, out MailAddress? mailAddress))
        {
            return new SubscriberId { Email = mailAddress };
        }

        throw new InvalidEmailAddressException();
    }
}
