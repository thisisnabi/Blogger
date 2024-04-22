using Blogger.Application.Usecases.MakeComment;

namespace Blogger.APIs.Contracts.MakeComment;

public class MakeCommentEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("comments/", async (
                [FromBody] MakeCommetRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<MakeCommentCommand>(request);
            var response = await mediator.Send(command, cancellationToken);

            return mapper.Map<MakeCommentResponse>(response);
        }).Validator<MakeCommetRequest>();
    }
}
