namespace Blogger.Application.Usecases.GetTags;
public record GetTagsQuery() 
    : IRequest<IReadOnlyList<GetTagsQueryResponse>>;