using Blogger.Application.Usecases.MakeComment;

namespace Blogger.APIs.Contracts.MakeComment;

public class ReplayToCommetEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        //app.MapPost("comments/{article-id}", async (
        //        [FromBody] ReplayToCommetRequest request,
        //        IMapper mapper,
        //        IMediator mediator,
        //        CancellationToken cancellationToken) =>
        //{
        //    var command = mapper.Map<MakeCommentCommand>(request);
        //    var response = await mediator.Send(command, cancellationToken);

        //    return mapper.Map<ReplayToCommetResponse>(response);
        //}).Validator<ReplayToCommetRequest>();
    }
}
