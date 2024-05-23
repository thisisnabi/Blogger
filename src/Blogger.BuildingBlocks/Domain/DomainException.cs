namespace Blogger.BuildingBlocks.Domain;

public abstract class DomainException : Exception
{
    protected DomainException() : base() { }

    protected DomainException(string? message) : base(message) { }
}