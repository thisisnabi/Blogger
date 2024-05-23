using Blogger.BuildingBlocks.Exceptions;

namespace Blogger.Domain.CommentAggregate;

public class Client : ValueObject<Client>
{
    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return FullName;
        yield return Email;
    }

    public static Client Create(string fullName, string email)
    {
        InvalidEmailAddressException.Throw(email);

        return new Client
        {
            Email = email,
            FullName = fullName,
        };
    }
}
