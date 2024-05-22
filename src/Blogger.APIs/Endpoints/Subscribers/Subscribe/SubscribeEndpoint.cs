using Blogger.APIs.Endpoints;
using Blogger.Application.Subscribers.Subscribe;

namespace Blogger.APIs.Endpoints.Subscribers.Subscribe;

public class SubscribeEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/subscribe", async (
                [FromBody] SubscribeRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<SubscribeCommand>(request);
            await mediator.Send(command, cancellationToken);
        }).Validator<SubscribeRequest>()
          .WithTags(EndpointSchema.SubscriberTag);
    }
}
