namespace Blogger.Domain.Common.Exceptions;

public abstract class BlogException : Exception
{
    protected BlogException() : base() { }

    protected BlogException(string? message) : base(message) { }
}