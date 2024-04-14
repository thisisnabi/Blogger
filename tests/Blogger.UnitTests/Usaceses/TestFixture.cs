using Mapster;

namespace Blogger.UnitTests.Usaceses;

public class TestFixture
{
    static TestFixture()
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        var applicationAssembly = AppDomain.CurrentDomain.GetAssemblies();
        typeAdapterConfig.Scan(applicationAssembly);
    }
}
