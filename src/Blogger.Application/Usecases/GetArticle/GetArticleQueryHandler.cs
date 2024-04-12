using Blogger.Application.Usecases.MakeComment;

namespace Blogger.Application.Usecases.GetArticle;

public class GetArticlesQueryHandler(IArticleRepository articleRepository) : IRequestHandler<GetArticleQuery, GetArticleQueryResponse>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<GetArticleQueryResponse> Handle(GetArticleQuery request, CancellationToken cancellationToken)
    {
        var article = await _articleRepository.GetArticleById(request.articleId, cancellationToken);

        if (article is null)
        {
            throw new NotFoundArticleException();
        }

        return new GetArticleQueryResponse(
           article.Id,
           article.Title,
           article.Body,
           article.Summery,
           article.GetReadOnInMinutes,
           article.Author,
           article.PublishedOnUtc,
           article.Tags);
    }
}
