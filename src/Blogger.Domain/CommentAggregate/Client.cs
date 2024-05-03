using Blogger.Domain.Common.Exceptions;

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

    public static Client Create(string fullName, string email)
    {
        if (MailAddress.TryCreate(email, out _))
        {
            return new Client
            {
                Email = email,
                FullName = fullName,
            };
        }

        throw new InvalidEmailAddressException();
    }
}
