using Blogger.APIs.Endpoints.GetPopularTags;
using Blogger.Application.Usecases.GetPopularTags;

namespace Blogger.APIs.Contracts.GetPopularTags;

public static class GetPopularTagsEndpoint
{
    private const int SizeOfTopPopular = 7;

    public static async Task<GetPopularTagsResponse> GetPopularTags(
        IMapper mapper,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new GetPopularTagsQuery(SizeOfTopPopular);
        var response = await mediator.Send(command, cancellationToken);

        return mapper.Map<GetPopularTagsResponse>(response);
    }
}
