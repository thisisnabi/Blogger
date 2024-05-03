using System.Net.Mail;
using Blogger.Domain.Common.Exceptions;

namespace Blogger.Domain.SubscriberAggregate;

public class SubscriberId : ValueObject<SubscriberId>
{
    public string Email { get; set; }

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return Email;
    }

    public static SubscriberId CreateUniqueId(string email)
    {
        if (MailAddress.TryCreate(email, out _))
        {
            return new SubscriberId { Email = email };
        }

        throw new InvalidEmailAddressException();
    }

    public static SubscriberId Create(string value) =>
        new SubscriberId { Email = value };
}
