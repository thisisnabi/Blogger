using Blogger.Application.ApplicatioServices;
using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.ReplayToComment;

public class ReplayToCommentCommandHandler(
    ICommentRepository commentRepository,
    IEmailService emailService,
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

        var content = EmailTemplates.ConfirmEngagementEmail;
        await emailService.SendAsync(request.Client.Email,
            ApplicationSettings.ApproveLink.ConfirmEmailSubject,
            content,
            cancellationToken);

        return new ReplayToCommentCommandResponse(replay.Id);
    }
}
