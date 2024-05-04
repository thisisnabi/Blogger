using Blogger.APIs.Endpoints;
using Blogger.Application.Comments.ApproveReply;

namespace Blogger.APIs.Endpoints.Comments.ApproveReply;

public class ApproveReplyEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/comments/replies/approve", async (
                [AsParameters] ApproveReplyRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<ApproveReplyCommand>(request);
            var result = await mediator.Send(command, cancellationToken);

            return Results.LocalRedirect($"/articles/{result.ArticleId}?comment-id={result.CommentId}&reply-id={result.ReplyId}");
        }).Validator<ApproveReplyRequest>()
          .WithTags(EndpointSchema.CommentTag);
    }
}
