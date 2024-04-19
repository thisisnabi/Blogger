namespace Blogger.APIs.Contracts.CreateArticle;

public static class CreateArticleEndPoint
{
    public static async Task<CreateArticleResponse> CreateArticle(
        [FromBody] CreateArticleRequest request,
        IMapper mapper,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = mapper.Map<CreateArticleCommand>(request);
        var response = await mediator.Send(command, cancellationToken);

        return mapper.Map<CreateArticleResponse>(response);
    }
}
