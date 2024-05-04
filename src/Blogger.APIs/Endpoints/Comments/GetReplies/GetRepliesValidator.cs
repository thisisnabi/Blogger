namespace Blogger.APIs.Endpoints.Comments.GetReplies;

public class GetRepliesValidator : AbstractValidator<GetRepliesRequest>
{
    public GetRepliesValidator()
    {
        RuleFor(x => x.CommentId)
            .NotEmpty()
            .NotNull();
    }
}