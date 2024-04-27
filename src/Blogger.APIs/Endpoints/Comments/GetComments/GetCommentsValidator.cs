namespace Blogger.APIs.Endpoints.Comments.GetComments;

public class GetCommentsValidator : AbstractValidator<GetCommentsRequest>
{
    public GetCommentsValidator()
    {
        RuleFor(x => x.ArticleId)
            .NotEmpty()
            .NotNull();
    }
}