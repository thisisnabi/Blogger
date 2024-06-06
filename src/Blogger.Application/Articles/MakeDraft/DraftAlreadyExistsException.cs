using Blogger.BuildingBlocks.Domain;

namespace Blogger.Application.Articles.MakeDraft;

public sealed class DraftAlreadyExistsException : DomainException
{
    private const string _messages = "Draft with Title `{0}` already exists.";
    public DraftAlreadyExistsException(string articleId)
        : base(string.Format(_messages, articleId))
    {
    }
}
