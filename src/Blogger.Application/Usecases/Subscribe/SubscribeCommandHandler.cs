using Blogger.Domain.SubscriberAggregate;

namespace Blogger.Application.Usecases.Subscribe;
public class SubscribeCommandHandler(ISubscruiberRepository subscruiberRepository,
    ISubscriberService subscriberService) : IRequestHandler<SubscribeCommand>
{
    private readonly ISubscruiberRepository _subscruiberRepository = subscruiberRepository;
    private readonly ISubscriberService _subscriberService = subscriberService;

    public async Task Handle(SubscribeCommand request, CancellationToken cancellationToken)
    {

        if (await _subscriberService.IsDuplicated(request.SubscriberId, cancellationToken))
        {
            // TODO: Create custom exception on this feateur
            throw new Exception("Duplicated registration!");
        }

        var subscriber = Subscriber.Create(request.SubscriberId);
        await _subscruiberRepository.CreateAsync(subscriber, cancellationToken);

        await _subscruiberRepository.SavaChangesAsync(cancellationToken);
    }
}
