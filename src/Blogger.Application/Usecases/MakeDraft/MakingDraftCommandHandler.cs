namespace Blogger.Application.Usecases.MakeDraft;

public class MakeDraftCommandHandler(IArticleRepository articleRepository) : IRequestHandler<MakeDraftCommand, MakeDraftCommandResponse>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<MakeDraftCommandResponse> Handle(MakeDraftCommand request, CancellationToken cancellationToken)
    {
        var article = Article.CreateDraft(request.title, request.body, request.summery);
        article.AddTags(request.Tags);

        await _articleRepository.CreateAsync(article, cancellationToken);

        await _articleRepository.SaveChangesAsync(cancellationToken);

        return new MakeDraftCommandResponse(article.Id);
    }
}
