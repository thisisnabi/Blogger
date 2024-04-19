namespace Blogger.APIs.Contracts.GetPopularTags;

public class GetPopularTagsEndpoint : IEndpoint
{
    private const int SizeOfTopPopular = 7;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/tags/popular", async (
        IMapper mapper,
        IMediator mediator,
        CancellationToken cancellationToken) =>
        {
            var command = new GetPopularTagsQuery(SizeOfTopPopular);
            var response = await mediator.Send(command, cancellationToken);

            return mapper.Map<GetPopularTagsResponse>(response);
        });
    }
}
