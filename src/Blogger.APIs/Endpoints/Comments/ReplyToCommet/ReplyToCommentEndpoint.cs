using Blogger.APIs.Endpoints;
using Blogger.Application.Comments.ReplyToComment;

namespace Blogger.APIs.Endpoints.Comments.ReplyToCommet;

public class ReplyToCommentEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("comments/{comment-id}/reply", async (
                [AsParameters] ReplyToCommentRequestModel request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<ReplyToCommentCommand>(request);
            var response = await mediator.Send(command, cancellationToken);

            return mapper.Map<ReplyToCommentResponse>(response);
        }).Validator<ReplyToCommentRequestModel>()
          .WithTags(EndpointSchema.CommentTag);
    }
}
