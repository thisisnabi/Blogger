namespace Blogger.Application.UpdateDraft;

public class UpdateDraftCommandHandler(IArticleRepository articleRepository) : IRequestHandler<UpdateDraftCommand>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task Handle(UpdateDraftCommand request, CancellationToken cancellationToken)
    {
        var draft = _articleRepository.GetDraftById(request.ArticleId);

        if (draft is null) throw new NotFoundDraftException();

        draft.UpdateDraft(request.title, request.summery, request.body);

        draft.UpdateTags(request.Tags);

        await _articleRepository.SaveChangesAsync(cancellationToken);
    }
}
