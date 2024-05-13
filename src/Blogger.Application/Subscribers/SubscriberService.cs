namespace Blogger.Application.Subscribers;

public class SubscriberService(ISubscriberRepository subscriberRepository) : ISubscriberService
{
    private readonly ISubscriberRepository _subscriberRepository = subscriberRepository;

    public async Task<bool> IsDuplicated(SubscriberId subscriberId, CancellationToken cancellationToken)
    {
        var exists = await _subscriberRepository.IsExistsAsync(subscriberId, cancellationToken);
        return exists;
    }
}
