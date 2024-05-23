using Blogger.BuildingBlocks.Domain;


namespace Blogger.Application.Articles.UpdateDraft;
public class DraftNotFoundException : DomainException
{
    private const string _message = "Draft not found.";

    public DraftNotFoundException() : base(_message)
    {

    }
}
