namespace Blogger.Application.Usecases.GetArticleArchive;
public record GetArticleArchiveQuery(int PageNumber = 1, int PageSize = 10) 
    : IRequest<IReadOnlyList<GetArticleArchiveQueryResponse>>;