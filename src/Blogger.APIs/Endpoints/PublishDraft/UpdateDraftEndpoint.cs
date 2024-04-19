namespace Blogger.APIs.Contracts.PublishDraft;

public class PublishDraftEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/articles/{DraftId}/publish", async (
                [AsParameters] PublishDraftRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<PublishDraftCommand>(request);
            await mediator.Send(command, cancellationToken);
        }).Validator<PublishDraftRequest>();
    }
}
