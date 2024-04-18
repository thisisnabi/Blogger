using Blogger.Application.Common;
using Blogger.Application.Services;
using Blogger.Application.Usecases.MakeComment;
using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.ReplayToComment;

public class ReplayToCommentCommandHandler(
    ICommentRepository commentRepository,
    ILinkGenerator linkGenerator) : IRequestHandler<ReplayToCommentCommand, ReplayToCommentCommandResponse>
{
    private readonly ICommentRepository _commentRepository = commentRepository;
    private readonly ILinkGenerator _linkGenerator = linkGenerator;

    public async Task<ReplayToCommentCommandResponse> Handle(ReplayToCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetCommentByIdAsync(request.CommentId, cancellationToken);

        // change into the NotFoundCommentException
        if (comment is null) throw new NotFoundArticleException();

        var link = _linkGenerator.Generate();
        var approveLink = ApproveLink.Create(link, DateTime.UtcNow.AddHours(ApplicationSettings.ApproveLink.ExpairationOnHours));
    
        var replay = comment.ReplayComment(request.Client, request.content, approveLink);

        await _commentRepository.SaveChangesAsync(cancellationToken);
        return new ReplayToCommentCommandResponse(replay.Id);
    }
}
