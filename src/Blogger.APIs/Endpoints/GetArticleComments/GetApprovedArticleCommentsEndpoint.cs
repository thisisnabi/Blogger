using Blogger.Application.Usecases.GetArticleComments;
namespace Blogger.APIs.Contracts.GetArticleComments;

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
            var command = mapper.Map<GetArticleCommentsQuery>(request);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetApprovedArticleCommentsResponse>>(result);
        }).Validator<GetApprovedArticleCommentsRequest>();
    }
}
