using Blogger.APIs.Endpoints;
using Blogger.Application.Articles.GetArticles;

namespace Blogger.APIs.Endpoints.Articles.GetArticles;

public class GetArticlesEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/articles/", async (
                [AsParameters] GetArticlesRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<GetArticlesQuery>(request);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetArticlesResponse>>(result);
        }).WithTags(EndpointSchema.ArticleTag);
    }
}
