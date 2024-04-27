using Blogger.Application.Subscribers.Subscribe;
using Blogger.Domain.SubscriberAggregate;

namespace Blogger.APIs.Endpoints.Subscribers.Subscribe;

public class SubscribeMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<SubscribeRequest, SubscribeCommand>()
                   .Map(x => x.SubscriberId, src => SubscriberId.Create(src.Email));
    }
}
