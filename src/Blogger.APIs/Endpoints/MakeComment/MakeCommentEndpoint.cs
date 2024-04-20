using Blogger.Application.Usecases.MakeComment;

namespace Blogger.APIs.Contracts.MakeComment;

public class MakeCommentEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("Articles/{article-id}/comments", async (
                [FromBody] MakeCommentRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<MakeCommentCommand>(request);
            var response = await mediator.Send(command, cancellationToken);

            return mapper.Map<MakeCommentResponse>(response);
        }).Validator<MakeCommentRequest>();
    }
}
