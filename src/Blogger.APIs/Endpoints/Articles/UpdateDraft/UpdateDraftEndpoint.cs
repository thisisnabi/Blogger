using Blogger.APIs.Endpoints;
using Blogger.Application.Articles.UpdateDraft;

namespace Blogger.APIs.Endpoints.Articles.UpdateDraft;

public class UpdateDraftEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/articles/draft", async (
                [FromBody] UpdateDraftRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<UpdateDraftCommand>(request);
            await mediator.Send(command, cancellationToken);
        }).Validator<UpdateDraftRequest>()
          .WithTags(EndpointSchema.ArticleTag);
    }
}
