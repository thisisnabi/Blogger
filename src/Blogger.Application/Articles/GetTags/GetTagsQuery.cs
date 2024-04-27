namespace Blogger.Application.Articles.GetTags;
public record GetTagsQuery()
    : IRequest<IReadOnlyList<GetTagsQueryResponse>>;