namespace Blogger.Application.Usecases.GetArticle;

public class GetArticleQueryHandler(IArticleRepository articleRepository) : IRequestHandler<GetArticleQuery, GetArticleQueryResponse>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<GetArticleQueryResponse> Handle(GetArticleQuery request, CancellationToken cancellationToken)
    {
        var article = await _articleRepository.GetArticleById(request.articleId,cancellationToken);

        return new GetArticleQueryResponse (
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
