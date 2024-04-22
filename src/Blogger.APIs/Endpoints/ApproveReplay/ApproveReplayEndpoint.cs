using Blogger.APIs.Endpoints;
using Blogger.Application.Usecases.ApproveReplay;

namespace Blogger.APIs.Contracts.ApproveReplay;

public class ApproveReplayEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/comments/replaies/approve", async (
                [AsParameters] ApproveReplayRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<ApproveReplayCommand>(request);
            var result = await mediator.Send(command, cancellationToken);

            return Results.LocalRedirect($"/articles/{result.ArticleId}?comment-id={result.CommentId}&replay-id={result.ReplayId}");
        }).Validator<ApproveReplayRequest>()
          .WithTags(EndpointSchema.CommentTag);
    }
}
