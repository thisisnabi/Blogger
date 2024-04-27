using Blogger.APIs.Endpoints;
using Blogger.Application.Comments.ApproveComment;

namespace Blogger.APIs.Endpoints.Comments.ApproveComment;

public class ApproveCommentEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/comments/approve", async (
                [AsParameters] ApproveCommentRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<ApproveCommentCommand>(request);
            var result = await mediator.Send(command, cancellationToken);

            return Results.LocalRedirect($"/articles/{result.ArticleId}?comment-id={result.CommentId}");
        }).Validator<ApproveCommentRequest>()
          .WithTags(EndpointSchema.CommentTag);
    }
}
