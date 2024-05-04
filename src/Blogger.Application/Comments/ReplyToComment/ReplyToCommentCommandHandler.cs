using Blogger.Application.ApplicationServices;
using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.ReplyToComment;

public class ReplyToCommentCommandHandler(
    ICommentRepository commentRepository,
    IEmailService emailService,
    ILinkGenerator linkGenerator) : IRequestHandler<ReplyToCommentCommand, ReplyToCommentCommandResponse>
{
    public async Task<ReplyToCommentCommandResponse> Handle(ReplyToCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await commentRepository.GetCommentByIdAsync(request.CommentId, cancellationToken);
        if (comment is null) throw new NotFoundCommentException();

        var link = linkGenerator.Generate();
        var approveLink = ApproveLink.Create(link, DateTime.UtcNow.AddHours(ApplicationSettings.ApproveLink.ExpairationOnHours));

        var Reply = comment.ReplyComment(request.Client, request.Content, approveLink);

        await commentRepository.SaveChangesAsync(cancellationToken);

        var content = EmailTemplates.ConfirmEngagementEmail;
        await emailService.SendAsync(request.Client.Email,
            ApplicationSettings.ApproveLink.ConfirmEmailSubject,
            content,
            cancellationToken);

        return new ReplyToCommentCommandResponse(Reply.Id);
    }
}
