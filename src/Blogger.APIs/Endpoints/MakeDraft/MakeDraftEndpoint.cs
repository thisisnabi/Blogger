namespace Blogger.APIs.Contracts.MakeDraft;

public class MakeDraftEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/articles/draft", async (
                [FromBody] MakeDraftRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<MakeDraftCommand>(request);
            var response = await mediator.Send(command, cancellationToken);

            return mapper.Map<MakeDraftResponse>(response);
        }).Validator<MakeDraftRequest>();
    }
}
