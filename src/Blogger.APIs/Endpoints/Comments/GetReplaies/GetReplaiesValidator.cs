namespace Blogger.APIs.Endpoints.Comments.GetReplaies;

public class GetReplaiesValidator : AbstractValidator<GetReplaiesRequest>
{
    public GetReplaiesValidator()
    {
        RuleFor(x => x.CommentId)
            .NotEmpty()
            .NotNull();
    }
}