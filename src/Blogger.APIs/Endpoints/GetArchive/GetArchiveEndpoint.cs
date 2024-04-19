namespace Blogger.APIs.Contracts.GetArchive;

public class GetArchiveEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/articles/archive", async (
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = new GetArchiveQuery();
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetArchiveResponse>>(result);
        });
    }
}