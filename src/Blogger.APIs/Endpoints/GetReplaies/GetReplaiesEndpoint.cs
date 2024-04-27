using Blogger.APIs.Endpoints;
using Blogger.Application.Comments.GetReplaies;

namespace Blogger.APIs.Contracts.GetReplaies;

public class GetReplaiesEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/comments/replaies/{comment-id}", async (
                [AsParameters] GetReplaiesRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<GetReplaiesQuery>(request);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetReplaiesResponse>>(result);
        }).Validator<GetReplaiesRequest>()
        .WithTags(EndpointSchema.ArticleTag);
    }
}
