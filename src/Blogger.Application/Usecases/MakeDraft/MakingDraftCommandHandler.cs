namespace Blogger.Application.Usecases.MakeDraft;

public class MakeDraftCommandHandler(IArticleRepository articleRepository) 
    : IRequestHandler<MakeDraftCommand, MakeDraftCommandResponse>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<MakeDraftCommandResponse> Handle(MakeDraftCommand request, CancellationToken cancellationToken)
    {
        var draft = Article.CreateDraft(request.title, request.body, request.summary);
        draft.AddTags(request.Tags);

        await _articleRepository.CreateAsync(draft, cancellationToken);
        await _articleRepository.SaveChangesAsync(cancellationToken);

        return new MakeDraftCommandResponse(draft.Id);
    }
}
