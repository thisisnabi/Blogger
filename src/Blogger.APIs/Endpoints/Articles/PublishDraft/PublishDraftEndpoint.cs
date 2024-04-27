using Blogger.APIs.Endpoints;
using Blogger.Application.Articles.PublishDraft;

namespace Blogger.APIs.Endpoints.Articles.PublishDraft;

public class PublishDraftEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/articles/{draft-id}/publish", async (
                [AsParameters] PublishDraftRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<PublishDraftCommand>(request);
            await mediator.Send(command, cancellationToken);
        }).Validator<PublishDraftRequest>()
        .WithTags(EndpointSchema.ArticleTag);
    }
}
