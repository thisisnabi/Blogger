namespace Blogger.Domain.Common.Exceptions;

public class InvalidEmailAddressException : DomainException
{
    private const string _messages = "Invalid Email Address.";

    public InvalidEmailAddressException() : base(_messages) { }
}