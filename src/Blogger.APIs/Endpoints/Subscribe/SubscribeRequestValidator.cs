using Blogger.APIs.Contracts.Subscribe;

namespace Blogger.APIs.Contracts.UpdateDraft;

public class SubscribeRequestValidator : AbstractValidator<SubscribeRequest>
{
    public SubscribeRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull();
    }
}