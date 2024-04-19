namespace Blogger.Application.Usecases.GetPopularTags;
public record GetPopularTagsQuery(int Size) 
    : IRequest<GetPopularTagsQueryResponse>;