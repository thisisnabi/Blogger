using Blogger.Domain.Common.Exceptions;

namespace Blogger.Domain.SubscriberAggregate;

public class SubscriberId : ValueObject<SubscriberId>
{
    public MailAddress Email { get; init; } = null!;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Email;
    }

    public static SubscriberId CreateUniqueId(string email)
    {
        if (MailAddress.TryCreate(email, out MailAddress? mailAddress))
        {
            return new SubscriberId { Email = mailAddress };
        }

        throw new InvalidEmailAddressException();
    }

    public static SubscriberId Create(string value) =>
        new SubscriberId { Email = new MailAddress(value) };
}
