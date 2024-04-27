namespace Blogger.Application.Articles.UpdateDraft;
public class DraftNotFoundException : Exception
{
    private const string _message = "Draft not found.";

    public DraftNotFoundException() : base(_message)
    {

    }
}
