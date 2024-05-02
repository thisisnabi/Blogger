namespace Blogger.Domain.Common.Exceptions;

public class InvalidEmailAddressException : BlogException
{
    private const string _messages = "Invalid Email Address";

    public InvalidEmailAddressException() : base(_messages) { }
}