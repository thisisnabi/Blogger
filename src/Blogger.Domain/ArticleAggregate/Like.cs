using System.Net;

namespace Blogger.Domain.ArticleAggregate;
public class Like : ValueObject<Like>
{
    public IPAddress IPAddress { get; init; } = null!;

    public DateTime LikedOn { get; set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return IPAddress;
        yield return LikedOn;
    }

    public static Like Create(string userIp, DateTime likedOn)
    {
        if (!IPAddress.TryParse(userIp, out IPAddress? ipAddress))
        {
            throw new ArgumentOutOfRangeException(nameof(userIp));
        }

        return new Like
        {
            IPAddress = ipAddress,
            LikedOn = likedOn
        };
    }
}
