using Blogger.APIs.Endpoints;
using Blogger.APIs.Endpoints.GetTags;
using Blogger.Application.Usecases.GetTags;

namespace Blogger.APIs.Contracts.GetTags;

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
