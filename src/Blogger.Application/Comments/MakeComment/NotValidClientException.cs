using Blogger.Domain.Common;

namespace Blogger.Application.Comments.MakeComment;

public class NotValidClientException : BlogException
{
    private const string _messages = "Invalid client id.";

    public NotValidClientException() : base(_messages)
    {

    }
}