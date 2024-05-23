namespace Blogger.Domain.Common.Exceptions;

public abstract class DomainException : Exception
{
    protected DomainException() : base() { }

    protected DomainException(string? message) : base(message) { }
}