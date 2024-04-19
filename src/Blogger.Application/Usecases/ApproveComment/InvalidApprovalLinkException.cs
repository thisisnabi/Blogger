namespace Blogger.Application.Usecases.ApproveComment;

public class InvalidApprovalLinkException : Exception
{
    private const string _message = "Invalid approved link.";
    public InvalidApprovalLinkException() : base(_message)
    {
    }
}
