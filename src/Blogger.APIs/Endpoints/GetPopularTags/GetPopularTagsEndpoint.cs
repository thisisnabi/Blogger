using Blogger.APIs.Endpoints;
using Blogger.APIs.Endpoints.GetPopularTags;
using Blogger.Application.Usecases.GetPopularTags;

namespace Blogger.APIs.Contracts.GetPopularTags;

public class GetPopularTagsEndpoint : IEndpoint
{
    private const int SizeOfTopPopular = 7;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/articles/tags/popular", async (
        IMapper mapper,
        IMediator mediator,
        CancellationToken cancellationToken) =>
        {
            var command = new GetPopularTagsQuery(SizeOfTopPopular);
            var response = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetPopularTagsResponse>>(response);
        }).WithTags(EndpointSchema.ArticleTag);
    }
}
