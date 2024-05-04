namespace Blogger.APIs.Endpoints.Comments.ReplyToCommet;

public class ReplyToCommentRequestValidator : AbstractValidator<ReplyToCommentRequestModel>
{
    public ReplyToCommentRequestValidator()
    {
        RuleFor(x => x.CommentId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.body.Content)
            .MaximumLength(500)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.body.FullName)
            .MaximumLength(100)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.body.Email)
            .MaximumLength(1044)
            .NotEmpty()
            .NotNull();
    }
}