
namespace Blogger.APIs.Contracts.ConvertToArticle;

public class ConvertToArticleEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/articles/{DraftId}/publish", async (
                [AsParameters] ConvertToArticleRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<ConvertToArticleCommand>(request);
            await mediator.Send(command, cancellationToken);
        }).Validator<ConvertToArticleRequest>();
    }
}
