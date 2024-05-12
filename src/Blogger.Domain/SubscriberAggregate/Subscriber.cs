using Blogger.Domain.ArticleAggregate;

namespace Blogger.Domain.SubscriberAggregate;

public class Subscriber(SubscriberId id) : AggregateRootBase<SubscriberId>(id)
{
    public DateTime JoinedOnUtc { get; init; }

    private readonly IList<ArticleId> _articleIds = null!;
    public IReadOnlyCollection<ArticleId> ArticleIds => [.. _articleIds];

    public static Subscriber Create(SubscriberId subscriberId)
         => new(subscriberId)
         {
             JoinedOnUtc = DateTime.UtcNow
         };
}
