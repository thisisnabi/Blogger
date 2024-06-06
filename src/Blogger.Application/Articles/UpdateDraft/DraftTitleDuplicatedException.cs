using Blogger.BuildingBlocks.Domain;


namespace Blogger.Application.Articles.UpdateDraft;
public class DraftTitleDuplicatedException : DomainException
{
    private const string _message = "A draft with the same title already exists. Draft title: {0}";

    public DraftTitleDuplicatedException(string title) : base(string.Format(_message, title))
    {

    }
}
