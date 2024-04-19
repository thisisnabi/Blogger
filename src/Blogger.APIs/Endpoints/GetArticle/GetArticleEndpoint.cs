using Blogger.Application.Usecases.GetArticle;

namespace Blogger.APIs.Contracts.GetArticle;

public class GetArticleEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/articles/{article-id}", async (
                [AsParameters] GetArticleRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<GetArticleQuery>(request);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<GetArticleResponse>(result);
        }).Validator<GetArticleRequest>();
    }
}
