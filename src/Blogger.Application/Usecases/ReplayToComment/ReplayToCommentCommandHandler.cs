using Blogger.Application.Common;
using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.ReplayToComment;

public class ReplayToCommentCommandHandler(
    ICommentRepository commentRepository,
    ILinkGenerator linkGenerator) : IRequestHandler<ReplayToCommentCommand, ReplayToCommentCommandResponse>
{
    public async Task<ReplayToCommentCommandResponse> Handle(ReplayToCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await commentRepository.GetCommentByIdAsync(request.CommentId, cancellationToken);
        if (comment is null) throw new NotFoundCommentException();

        var link = linkGenerator.Generate();
        var approveLink = ApproveLink.Create(link, DateTime.UtcNow.AddHours(ApplicationSettings.ApproveLink.ExpairationOnHours));

        var replay = comment.ReplayComment(request.Client, request.Content, approveLink);

        await commentRepository.SaveChangesAsync(cancellationToken);
        return new ReplayToCommentCommandResponse(replay.Id);
    }
}
