using Blogger.Domain.ClientAggregate;

namespace Blogger.Application.Usecases.MakeComment;
public class MakeCommentCommandHandler(
    IArticleRepository articleRepository,
    IClientService clientService) : IRequestHandler<MakeCommentCommand>
{
    private readonly IArticleRepository _articleRepository = articleRepository;
    private readonly IClientService _clientService = clientService;
    public async Task Handle(MakeCommentCommand request, CancellationToken cancellationToken)
    {
        if (!await _clientService.IsValid(request.ClientId))
        {
            throw new NotValidClientException();
        }

        var article = await _articleRepository.GetArticleById(request.ArticleId);

        if (article is null) throw new NotFoundArticleException();

        var comment = Comment.Create(request.ClientId, request.content);
        article.AddComment(comment);

        await _articleRepository.SaveChangesAsync(cancellationToken);
    }
}
