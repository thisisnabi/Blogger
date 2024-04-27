using Blogger.Application.Articles.GetTags;

namespace Blogger.APIs.Endpoints.Articles.GetTags;

public class GetTagsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/articles/tags/", async (
        IMapper mapper,
        IMediator mediator,
        CancellationToken cancellationToken) =>
        {
            var command = new GetTagsQuery();
            var response = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetTagsResponse>>(response);
        }).WithTags(EndpointSchema.ArticleTag);
    }
}
