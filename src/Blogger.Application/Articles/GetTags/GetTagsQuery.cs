namespace Blogger.Application.Articles.GetTags;
public record GetTagsQuery()
    : IRequest<IReadOnlyCollection<GetTagsQueryResponse>>;