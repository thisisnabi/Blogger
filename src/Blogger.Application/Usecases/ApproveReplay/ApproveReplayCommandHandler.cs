using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.ApproveReplay;
public class ApproveReplayCommandHandler(ICommentRepository commentRepository) : IRequestHandler<ApproveReplayCommand, ApproveReplayCommandResponse>
{
    private readonly ICommentRepository _commentRepository = commentRepository;

    public async Task<ApproveReplayCommandResponse> Handle(ApproveReplayCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetCommentByIdAsync(request.CommentId, cancellationToken);
        if (comment is null)
        {
            throw new CommentNotFoundException();
        }

        comment.ApproveReplay(request.Link);
        await _commentRepository.SaveChangesAsync(cancellationToken);

        return new ApproveReplayCommandResponse(comment.ArticleId);
    }
}
