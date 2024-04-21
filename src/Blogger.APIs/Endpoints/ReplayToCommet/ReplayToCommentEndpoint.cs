using Blogger.APIs.Contracts.MakeComment;
using Blogger.APIs.Contracts.ReplayToCommet;
using Blogger.Application.Usecases.ReplayToComment;

namespace Blogger.APIs.Contracts.ReplayToComment;

public class ReplayToCommentEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        //app.MapPost("comments/{comment-id:guid}/replay", async (
        //        [FromBody] ReplayToCommentRequest request,
        //        IMapper mapper,
        //        IMediator mediator,
        //        CancellationToken cancellationToken) =>
        //{
        //    var command = mapper.Map<ReplayToCommentCommand>(request);
        //    var response = await mediator.Send(command, cancellationToken);

        //    return mapper.Map<ReplayToCommetResponse>(response);
        //}).Validator<ReplayToCommentRequest>();
    }
}
