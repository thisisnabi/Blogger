using Blogger.APIs.Endpoints;
using Blogger.Application.Articles.GetArticle;

namespace Blogger.APIs.Endpoints.Articles.GetArticle;

public class GetArticleEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/articles/{article-id}", async (
                [AsParameters] GetArticleRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<GetArticleQuery>(request);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<GetArticleResponse>(result);
        }).Validator<GetArticleRequest>()
        .WithTags(EndpointSchema.ArticleTag);
    }
}
