using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.ApproveReply;
public class ApproveReplyCommandHandler(ICommentRepository commentRepository) : IRequestHandler<ApproveReplyCommand, ApproveReplyCommandResponse>
{
    private readonly ICommentRepository _commentRepository = commentRepository;

    public async Task<ApproveReplyCommandResponse> Handle(ApproveReplyCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetCommentByIdAsync(request.CommentId, cancellationToken);
        if (comment is null)
        {
            throw new CommentNotFoundException();
        }

        var ReplyId = comment.ApproveReply(request.Link);
        await _commentRepository.SaveChangesAsync(cancellationToken);

        return new ApproveReplyCommandResponse(comment.ArticleId, comment.Id, ReplyId);
    }
}
