using Blogger.Application.Comments.GetReplies;

namespace Blogger.APIs.Endpoints.Comments.GetReplies;

public class GetRepliesEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/comments/replies/{comment-id}", async (
                [AsParameters] GetRepliesRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<GetRepliesQuery>(request);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetRepliesResponse>>(result);
        }).Validator<GetRepliesRequest>()
        .WithTags(EndpointSchema.ArticleTag);
    }
}
