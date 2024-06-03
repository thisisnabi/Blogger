namespace Blogger.Application.Articles.GetArchive;
public record GetArchiveQuery() : IRequest<IReadOnlyCollection<GetArchiveQueryResponse>>;