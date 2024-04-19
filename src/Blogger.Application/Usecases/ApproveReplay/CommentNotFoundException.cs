namespace Blogger.Application.Usecases.UpdateDraft;
public class CommentNotFoundException : Exception
{
    private const string _message = "Comment not found.";

    public CommentNotFoundException() : base(_message)
    {

    }
}
