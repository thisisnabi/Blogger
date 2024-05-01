namespace Blogger.Application.Subscribers;

public class SubscriberService(ISubscruiberRepository subscruiberRepository) : ISubscriberService
{
    private readonly ISubscruiberRepository _subscruiberRepository = subscruiberRepository;

    public async Task<bool> IsDuplicated(SubscriberId subscriberId, CancellationToken cancellationToken)
    {
        var exists = await _subscruiberRepository.IsExists(subscriberId, cancellationToken);
        return exists;
    }
}
