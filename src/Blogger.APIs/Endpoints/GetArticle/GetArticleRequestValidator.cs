namespace Blogger.APIs.Contracts.GetArticle;

public class GetArticleRequestValidator : AbstractValidator<GetArticleRequest>
{
    public GetArticleRequestValidator()
    {
        RuleFor(x => x.ArticleId)
            .NotEmpty()
            .NotNull();
    }
}