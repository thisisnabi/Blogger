namespace Blogger.Application.Usecases.UpdateDraft;

public class UpdateDraftCommandHandler(IArticleRepository articleRepository) : IRequestHandler<UpdateDraftCommand>
{
    public async Task Handle(UpdateDraftCommand request, CancellationToken cancellationToken)
    {
        var draft = await articleRepository.GetDraftByIdAsync(request.DraftId, cancellationToken);
        if (draft is null)
        {
            throw new DraftNotFoundException();
        }

        var draftId = ArticleId.CreateUniqueId(request.Title);
        if (await articleRepository.HasIdAsync(draftId, cancellationToken))
        {
            throw new DraftTitleDuplicatedException(draftId.ToString());
        }

        draft.UpdateDraft(draftId, request.Title, request.Summary, request.Body);
        draft.UpdateTags(request.Tags);

        await articleRepository.SaveChangesAsync(cancellationToken);
    }
}
