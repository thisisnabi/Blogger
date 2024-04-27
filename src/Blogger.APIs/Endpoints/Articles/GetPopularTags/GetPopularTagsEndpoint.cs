using Blogger.Application.Articles.GetPopularTags;

namespace Blogger.APIs.Endpoints.Articles.GetPopularTags;

public class GetPopularTagsEndpoint : IEndpoint
{
    private const int SizeOfTopPopular = 7;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/articles/tags/populars", async (
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
