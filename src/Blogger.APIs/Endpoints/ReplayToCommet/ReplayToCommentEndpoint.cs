using Blogger.APIs.Contracts.ReplayToCommet;
using Blogger.APIs.Endpoints;
using Blogger.Application.Comments.ReplayToComment;

namespace Blogger.APIs.Contracts.ReplayToComment;

public class ReplayToCommentEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("comments/{comment-id}/replay", async (
                [AsParameters] ReplayToCommentRequestModel request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<ReplayToCommentCommand>(request);
            var response = await mediator.Send(command, cancellationToken);

            return mapper.Map<ReplayToCommentResponse>(response);
        }).Validator<ReplayToCommentRequestModel>()
          .WithTags(EndpointSchema.CommentTag);
    }
}
