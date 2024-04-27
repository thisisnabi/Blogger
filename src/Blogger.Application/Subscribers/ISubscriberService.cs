namespace Blogger.Application.Subscribers;

public interface ISubscriberService
{
    Task<bool> IsDuplicated(SubscriberId subscriberId, CancellationToken cancellationToken);
}
