namespace Blogger.Application.MakingDraft;

public class MakingDraftCommandHandler(IArticleRepository articleRepository) : IRequestHandler<MakingDraftCommand, MakingDraftCommandResponse>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<MakingDraftCommandResponse> Handle(MakingDraftCommand request, CancellationToken cancellationToken)
    {
        var article = Article.CreateDraft(request.title, request.body, request.summery);
        article.AddTags(request.Tags);

        await _articleRepository.CreateAsync(article, cancellationToken);

        return new MakingDraftCommandResponse(article.Id);
    }
}
