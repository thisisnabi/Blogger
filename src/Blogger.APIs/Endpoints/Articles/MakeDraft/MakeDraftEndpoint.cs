using Blogger.APIs.Endpoints;
using Blogger.Application.Articles.MakeDraft;

namespace Blogger.APIs.Endpoints.Articles.MakeDraft;

public class MakeCommentEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/articles/draft", async (
                [FromBody] MakeDraftRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<MakeDraftCommand>(request);
            var response = await mediator.Send(command, cancellationToken);

            return mapper.Map<MakeDraftResponse>(response);
        }).Validator<MakeDraftRequest>()
        .WithTags(EndpointSchema.ArticleTag);
    }
}
