namespace Blogger.Application.Usecases.CreateArticle;

public class CreateArticleCommandHandler(IArticleRepository articleRepository) : IRequestHandler<CreateArticleCommand, CreateArticleCommandResponse>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<CreateArticleCommandResponse> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var article = Article.CreateArticle(request.title, request.body, request.summary);
        article.AddTags(request.Tags);

        await _articleRepository.CreateAsync(article, cancellationToken);
        await _articleRepository.SaveChangesAsync(cancellationToken);

        return new CreateArticleCommandResponse(article.Id);
    }
}
