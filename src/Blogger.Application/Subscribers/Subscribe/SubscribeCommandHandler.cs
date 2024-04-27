namespace Blogger.Application.Subscribers.Subscribe;
public class SubscribeCommandHandler(ISubscruiberRepository subscruiberRepository,
    ISubscriberService subscriberService) : IRequestHandler<SubscribeCommand>
{
    private readonly ISubscruiberRepository _subscruiberRepository = subscruiberRepository;
    private readonly ISubscriberService _subscriberService = subscriberService;

    public async Task Handle(SubscribeCommand request, CancellationToken cancellationToken)
    {

        if (await _subscriberService.IsDuplicated(request.SubscriberId, cancellationToken))
        {
            throw new DuplicateSubscribtionException();
        }

        var subscriber = Subscriber.Create(request.SubscriberId);
        await _subscruiberRepository.CreateAsync(subscriber, cancellationToken);

        await _subscruiberRepository.SavaChangesAsync(cancellationToken);
    }
}
