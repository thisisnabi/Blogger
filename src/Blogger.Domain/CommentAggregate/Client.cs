using System.Net.Mail;

namespace Blogger.Domain.CommentAggregate;

public class Client : ValueObject<Client>
{
    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return FullName;
        yield return Email;
    }

    private Client(string fullName, string email)
    {
        FullName = fullName;
        Email = email;
    }

    public static Client Create(string fullName, string email)
    {
        if (MailAddress.TryCreate(email, out _))
        {
            return new Client(fullName, email);
        }

        throw new ArgumentException("Invalid email address");
    }
}
