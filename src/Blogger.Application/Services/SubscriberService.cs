namespace Blogger.Application.Services;

public class SubscriberService(ISubscruiberRepository subscruiberRepository) : ISubscriberService
{
    private readonly ISubscruiberRepository _subscruiberRepository = subscruiberRepository;
 
    public async Task<bool> IsDuplicated(SubscriberId subscriberId, CancellationToken cancellationToken)
    {
        var subscriber = await _subscruiberRepository.FindById(subscriberId);
        return subscriber is not null;
    }
}
