using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.ApproveComment;
public class ApproveCommentCommandHandler(ICommentRepository commentRepository) : IRequestHandler<ApproveCommentCommand, ApproveCommentCommandResponse>
{
    private readonly ICommentRepository _commentRepository = commentRepository;

    public async Task<ApproveCommentCommandResponse> Handle(ApproveCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetCommentByApproveLinkAsync(request.Link, cancellationToken);
        if (comment is null)
        {
            throw new InvalidCommentApprovalLinkException();
        }

        comment.Approve();
        await _commentRepository.SaveChangesAsync(cancellationToken);

        return new ApproveCommentCommandResponse(comment.ArticleId, comment.Id);
    }
}
