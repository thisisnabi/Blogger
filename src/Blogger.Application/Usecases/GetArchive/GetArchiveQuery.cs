namespace Blogger.Application.Usecases.GetArchive;
public record GetArchiveQuery() : IRequest<IReadOnlyList<GetArchiveQueryResponse>>;