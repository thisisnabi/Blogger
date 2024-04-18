using Blogger.Application.Common;
using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.MakeComment;

public class MakeCommentCommandHandler(
    ICommentRepository commentRepository,
    IArticleService articleService,
    ILinkGenerator linkGenerator) : IRequestHandler<MakeCommentCommand, MakeCommentCommandResponse>
{
    private readonly ICommentRepository _commentRepository = commentRepository;
    private readonly IArticleService _articleService = articleService;
    private readonly ILinkGenerator _linkGenerator = linkGenerator;

    private const int ExpairationOnHours = 24;

    public async Task<MakeCommentCommandResponse> Handle(MakeCommentCommand request, CancellationToken cancellationToken)
    {
        var isArticleValid = await _articleService.IsArticleIdValidAsync(request.ArticleId, cancellationToken);
        if (!isArticleValid)
        {
            // TODO: Fix exception
            throw new NotFoundArticleException();
        }

        var link = _linkGenerator.Generate();
        var approveLink = ApproveLink.Create(link, DateTime.UtcNow.AddHours(ApplicationSettings.ApproveLink.ExpairationOnHours));

        var comment = Comment.Create(request.ArticleId, request.Client, request.content, approveLink);
        await _commentRepository.CreateAsync(comment, cancellationToken);
        await _commentRepository.SaveChangesAsync(cancellationToken);
         
        return new MakeCommentCommandResponse(comment.Id);
    }
}
