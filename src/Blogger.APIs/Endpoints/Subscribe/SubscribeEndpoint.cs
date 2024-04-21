using Blogger.Application.Usecases.Subscribe;

namespace Blogger.APIs.Contracts.Subscribe;

public class SubscribeEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        //app.MapPost("/Subscribe", async (
        //        [FromBody] SubscribeRequest request,
        //        IMapper mapper,
        //        IMediator mediator,
        //        CancellationToken cancellationToken) =>
        //{
        //    var command = mapper.Map<SubscribeCommand>(request);
        //    await mediator.Send(command, cancellationToken);
        //}).Validator<SubscribeRequest>();
    }
}
