namespace Blogger.Application.Articles.GetPopularTags;
public record GetPopularTagsQuery(int Size)
    : IRequest<IReadOnlyList<GetPopularTagsQueryResponse>>;