namespace Blogger.Domain.SubscriberAggregate;
public interface ISubscriberService
{
    Task<bool> IsDuplicated(SubscriberId subscriberId);
}
