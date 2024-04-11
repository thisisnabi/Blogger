using System.Net.Mail;

namespace Blogger.Domain.SubscriberAggregate;

public class SubscriberId : ValueObject<SubscriberId>
{
    public string Email { get; set; }

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return Email;
    }

    private SubscriberId(string email)
    {
        Email = email;
    }

    public static SubscriberId CreateUniqueId(string email)
    {
        if(MailAddress.TryCreate(email, out _)) 
        {
            return new SubscriberId(email);
        }

        throw new ArgumentException("Invalid email address");
    }
}
