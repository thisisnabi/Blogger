using Blogger.Domain.ArticleAggregate;

namespace Blogger.Application.Articles.UpdateDraft;

public class UpdateDraftCommandHandler(IArticleRepository articleRepository) : IRequestHandler<UpdateDraftCommand>
{
    public async Task Handle(UpdateDraftCommand request, CancellationToken cancellationToken)
    {
        var draft = await articleRepository.GetDraftByIdAsync(request.DraftId, cancellationToken);
        if (draft is null)
        {
            throw new DraftNotFoundException();
        }

        var newDraftId = ArticleId.CreateUniqueId(request.Title);
        if (!draft.Id.Equals(newDraftId) &&
             await articleRepository.HasIdAsync(newDraftId, cancellationToken))
        {
            throw new DraftTitleDuplicatedException(newDraftId.ToString());
        }

        if (draft.Id.Equals(newDraftId))
        {
            draft.UpdateDraft(request.Title, request.Summary, request.Body);
            draft.UpdateTags(request.Tags);
        }
        else
        {
            articleRepository.Delete(draft);

            var newDraft = Article.CreateDraft(request.Title, request.Body, request.Summary);
            if (request.Tags.Any())
            {
                newDraft.AddTags(request.Tags);
            }

            await articleRepository.CreateAsync(newDraft, cancellationToken);
        }

        await articleRepository.SaveChangesAsync(cancellationToken);
    }
}
