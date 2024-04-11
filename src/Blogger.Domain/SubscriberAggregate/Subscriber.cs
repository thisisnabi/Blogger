namespace Blogger.Domain.SubscriberAggregate;

public class Subscriber(SubscriberId id) : AggregateRootBase<SubscriberId>(id)
{
    public DateTime JoinedOnUtc { get; set; }

    public static Subscriber Create(SubscriberId subscriberId)
         => new Subscriber(subscriberId)
         {
             JoinedOnUtc = DateTime.UtcNow
         };
}
