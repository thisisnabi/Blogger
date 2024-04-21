namespace Blogger.APIs.Contracts.MakeDraft;

public class MakeCommentEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        //app.MapPost("/articles/draft", async (
        //        [FromBody] MakeCommentRequest request,
        //        IMapper mapper,
        //        IMediator mediator,
        //        CancellationToken cancellationToken) =>
        //{
        //    var command = mapper.Map<MakeDraftCommand>(request);
        //    var response = await mediator.Send(command, cancellationToken);

        //    return mapper.Map<MakeCommentResponse>(response);
        //}).Validator<MakeCommentRequest>();
    }
}
