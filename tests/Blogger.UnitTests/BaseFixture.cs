using AutoFixture;

namespace Blogger.UnitTests;

public class BaseFixture
{
    public Fixture Fixture { get; }

    public BaseFixture()
    {
        Fixture = new Fixture();
    }
}