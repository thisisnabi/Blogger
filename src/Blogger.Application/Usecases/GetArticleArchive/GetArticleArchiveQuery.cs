namespace Blogger.Application.Usecases.GetArticleArchive;
public record GetArticleArchiveQuery() 
    : IRequest<IReadOnlyList<GetArticleArchiveQueryResponse>>;