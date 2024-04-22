using Blogger.Application.Usecases.GetArticleComments;
namespace Blogger.APIs.Contracts.GetArticleComments;

public class GetArticleCommentsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/comments/{article-id}/approved", async (
                [AsParameters] GetArticleCommentsRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<GetArticleCommentsQuery>(request);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetArticleCommentsResponse>>(result);
        }).Validator<GetArticleCommentsRequest>();
    }
}
