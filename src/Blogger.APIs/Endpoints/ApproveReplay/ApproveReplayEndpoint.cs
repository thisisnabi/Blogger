using Blogger.Application.Usecases.ApproveReplay;

namespace Blogger.APIs.Contracts.ApproveReplay;

public class ApproveReplayEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        //app.MapGet("/comments/{comment-id:guid}/approve", async (
        //        [AsParameters] ApproveReplayRequest request,
        //        IMapper mapper,
        //        IMediator mediator,
        //        CancellationToken cancellationToken) =>
        //{
        //    var command = mapper.Map<ApproveReplayCommand>(request);
        //    var result = await mediator.Send(command, cancellationToken);

        //    return Results.LocalRedirect($"/articles/{result.ArticleId}");
        //}).Validator<ApproveReplayRequest>();
    }
}
