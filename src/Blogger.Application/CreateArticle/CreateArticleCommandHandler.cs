namespace Blogger.Application.CreateArticle;

public class CreateArticleCommandHandler(IArticleRepository articleRepository) : IRequestHandler<CreateArticleCommand, CreateArticleCommandResponse>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<CreateArticleCommandResponse> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var article = Article.CreateArticle(request.title, request.body, request.summery);
        article.AddTags(request.Tags);

        await _articleRepository.CreateAsync(article, cancellationToken);

        return new CreateArticleCommandResponse(article.Id);
    }
}
