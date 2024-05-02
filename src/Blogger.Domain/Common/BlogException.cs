namespace Blogger.Domain.Common;

public abstract class BlogException : Exception
{
    protected BlogException(string? message) : base(message) { }
}