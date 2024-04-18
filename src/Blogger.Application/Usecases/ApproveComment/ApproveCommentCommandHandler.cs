using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.ApproveComment;
public class ApproveCommentCommandHandler(ICommentRepository commentRepository) : IRequestHandler<ApproveCommentCommand>
{
    private readonly ICommentRepository _commentRepository = commentRepository;

    public async Task Handle(ApproveCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetCommentByApprovedLinkAsync(request.ApproveLink, cancellationToken);

        if (comment is null)
        {
            // to do use custom exception
            throw new Exception("Invalid approved linl///");
        }
 
        comment.Approve();
        await _commentRepository.SaveChangesAsync(cancellationToken);
    }
}
