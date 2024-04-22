namespace Blogger.APIs.Contracts.GetArticleComments;

public class GetArticleCommentsValidator : AbstractValidator<GetArticleCommentsRequest>
{
    public GetArticleCommentsValidator()
    {
        RuleFor(x => x.ArticleId)
            .NotEmpty()
            .NotNull();
    }
}