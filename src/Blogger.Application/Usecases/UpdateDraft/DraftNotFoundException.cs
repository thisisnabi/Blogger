namespace Blogger.Application.Usecases.UpdateDraft;
public class DraftNotFoundException : Exception
{
    private const string _message = "Draft not found.";

    public DraftNotFoundException() : base(_message)
    {

    }
}
