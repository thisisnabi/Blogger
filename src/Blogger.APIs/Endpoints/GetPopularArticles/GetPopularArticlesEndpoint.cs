using Blogger.APIs.Endpoints;
using Blogger.Application.Usecases.GetPopularArticles;

namespace Blogger.APIs.Contracts.GetPopularArticles;

public class GetPopularArticlesEndpoint : IEndpoint
{
    private const int SizeOfTopPopular = 7;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/articles/populars", async (
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<GetPopularArticlesQuery>(SizeOfTopPopular);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetPopularArticlesResponse>>(result);
        }).WithTags(EndpointSchema.ArticleTag);
    }
}
