namespace Blogger.Application.UpdateDraft;
public class NotFoundDraftException : Exception
{
    private const string _message = "Invalid draft!";

    public NotFoundDraftException() : base(_message)
    {

    }
}
