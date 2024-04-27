using Blogger.APIs.Endpoints;
using Blogger.Application.Comments.GetComments;

namespace Blogger.APIs.Endpoints.Comments.GetComments;

public class GetCommentsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/comments/{article-id}", async (
                [AsParameters] GetCommentsRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<GetCommentsQuery>(request);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetCommentsResponse>>(result);
        }).Validator<GetCommentsRequest>()
        .WithTags(EndpointSchema.CommentTag);
    }
}
