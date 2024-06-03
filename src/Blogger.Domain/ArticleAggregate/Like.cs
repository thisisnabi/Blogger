using System.Net;

namespace Blogger.Domain.ArticleAggregate;
public class Like : ValueObject<Like>
{
    public string ClientIP { get; init; } = null!;

    public DateTime LikedOn { get; set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return ClientIP;
        yield return LikedOn;
    }

    public static Like Create(string clientIp, DateTime likedOn)
    {
        if (!IPAddress.TryParse(clientIp, out IPAddress? ipAddress))
        {
            throw new ArgumentOutOfRangeException(nameof(clientIp));
        }

        return new Like
        {
            ClientIP = clientIp,
            LikedOn = likedOn
        };
    }
}
