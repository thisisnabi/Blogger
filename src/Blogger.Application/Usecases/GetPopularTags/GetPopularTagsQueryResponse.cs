namespace Blogger.Application.Usecases.GetPopularTags;

public record GetPopularTagsQueryResponse(IReadOnlyCollection<Tag> Tags);
