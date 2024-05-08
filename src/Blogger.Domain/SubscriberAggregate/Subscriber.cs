using Blogger.Domain.ArticleAggregate;

namespace Blogger.Domain.SubscriberAggregate;

public class Subscriber(SubscriberId id) : AggregateRootBase<SubscriberId>(id)
{
    public DateTime JoinedOnUtc { get; init; } 

    private IList<ArticleId> _articleIds = null!;
    public IReadOnlyCollection<ArticleId> ArticleIds => _articleIds.ToImmutableList();

    public static Subscriber Create(SubscriberId subscriberId)
         => new Subscriber(subscriberId)
         {
             JoinedOnUtc = DateTime.UtcNow
         };
}
