namespace Blogger.Application.Comments.GetComments;
public record GetCommentsQuery(ArticleId ArticleId)
    : IRequest<IReadOnlyList<GetCommentsQueryResponse>>;