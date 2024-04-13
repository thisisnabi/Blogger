namespace Blogger.Application.Usecases.UpdateDraft;

public class UpdateDraftCommandHandler(IArticleRepository articleRepository) : IRequestHandler<UpdateDraftCommand>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task Handle(UpdateDraftCommand request, CancellationToken cancellationToken)
    {
        var draft = await _articleRepository.GetDraftByIdAsync(request.ArticleId, cancellationToken);

        if (draft is null) throw new NotFoundDraftException();

        draft.UpdateDraft(request.title, request.summary, request.body);

        draft.UpdateTags(request.Tags);

        await _articleRepository.SaveChangesAsync(cancellationToken);
    }
}
