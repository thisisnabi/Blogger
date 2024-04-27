namespace Blogger.Application.Comments.ReplayToComment;
public class NotFoundCommentException : Exception
{
    private const string _message = "Invalid comment for replay!";

    public NotFoundCommentException() : base(_message)
    {

    }
}
