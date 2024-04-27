using Blogger.APIs.Endpoints;
using Blogger.Application.Articles.GetTaggedArticles;

namespace Blogger.APIs.Endpoints.Articles.GetTaggedArticles;

public class GetTaggedArticlesEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/articles/tagged", async (
                [AsParameters] GetTaggedArticlesRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<GetTaggedArticlesQuery>(request);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetTaggedArticlesResponse>>(result);
        }).WithTags(EndpointSchema.ArticleTag);
    }
}
