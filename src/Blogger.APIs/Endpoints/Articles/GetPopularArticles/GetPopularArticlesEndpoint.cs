using Blogger.Application.Articles.GetPopularArticles;

namespace Blogger.APIs.Endpoints.Articles.GetPopularArticles;

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
            var command = new GetPopularArticlesQuery(SizeOfTopPopular);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetPopularArticlesResponse>>(result);
        }).WithTags(EndpointSchema.ArticleTag);
    }
}
