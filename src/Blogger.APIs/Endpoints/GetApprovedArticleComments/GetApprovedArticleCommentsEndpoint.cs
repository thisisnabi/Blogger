using Blogger.Application.Usecases.GetApprovedArticleComments;

namespace Blogger.APIs.Contracts.GetApprovedArticleComments;

public class GetApprovedArticleCommentsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/comments/{article-id}/approved", async (
                [AsParameters] GetApprovedArticleCommentsRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<GetApprovedArticleCommentsQuery>(request);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetApprovedArticleCommentsResponse>>(result);
        }).Validator<GetApprovedArticleCommentsRequest>();
    }
}
