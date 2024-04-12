namespace Blogger.Application.Services;

public interface ISubscriberService
{
    Task<bool> IsDuplicated(SubscriberId subscriberId, CancellationToken cancellationToken);
}
