namespace Blogger.Domain.SubscriberAggregate;

public class Subscriber(SubscriberId id) : AggregateRootBase<SubscriberId>(id)
{
    public DateTime JoinedOnUtc { get; set; }
}
