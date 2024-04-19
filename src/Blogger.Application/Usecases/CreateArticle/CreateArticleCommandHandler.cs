namespace Blogger.Application.Usecases.CreateArticle;

public class CreateArticleCommandHandler(IArticleRepository articleRepository) : IRequestHandler<CreateArticleCommand, CreateArticleCommandResponse>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<CreateArticleCommandResponse> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var articleId = ArticleId.CreateUniqueId(request.Title);
        var oldArticle = await _articleRepository.GetArticleByIdAsync(articleId, cancellationToken);

        if (oldArticle is not null)
        {
            throw new ArticleAlreadyExistsException(articleId.ToString());
        }

        var article = Article.CreateArticle(request.Title, request.Body, request.Summary);
        article.AddTags(request.Tags);
         
        await _articleRepository.CreateAsync(article, cancellationToken);
        await _articleRepository.SaveChangesAsync(cancellationToken);
    
        return new CreateArticleCommandResponse(article.Id);
    }
}
