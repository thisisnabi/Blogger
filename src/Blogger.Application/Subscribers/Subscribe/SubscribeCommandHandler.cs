namespace Blogger.Application.Subscribers.Subscribe;
public class SubscribeCommandHandler(ISubscriberRepository subscriberRepository,
    ISubscriberService subscriberService) : IRequestHandler<SubscribeCommand>
{
    private readonly ISubscriberRepository _subscriberRepository = subscriberRepository;
    private readonly ISubscriberService _subscriberService = subscriberService;

    public async Task Handle(SubscribeCommand request, CancellationToken cancellationToken)
    {

        if (await _subscriberService.IsDuplicated(request.SubscriberId, cancellationToken))
        {
            throw new DuplicateSubscribtionException();
        }

        var subscriber = Subscriber.Create(request.SubscriberId);
        await _subscriberRepository.CreateAsync(subscriber, cancellationToken);

        await _subscriberRepository.SavaChangesAsync(cancellationToken);
    }
}
