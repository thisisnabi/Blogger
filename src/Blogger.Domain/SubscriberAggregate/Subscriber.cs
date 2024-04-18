using Blogger.Domain.ArticleAggregate;

namespace Blogger.Domain.SubscriberAggregate;

public class Subscriber(SubscriberId id) : AggregateRootBase<SubscriberId>(id)
{
    public DateTime JoinedOnUtc { get; set; }

    private IList<ArticleId> _articleIds = null!;
    public IReadOnlyCollection<ArticleId> ArticleId => _articleIds.ToImmutableList();

    public static Subscriber Create(SubscriberId subscriberId)
         => new Subscriber(subscriberId)
         {
             JoinedOnUtc = DateTime.UtcNow
         };
}
