using FluentAssertions;

namespace Blogger.ArchitectureTests.Dependencies;

public class ArchitectureDependencyTests
{
    private const string RootAssemblyName = "Blogger";

    [Fact]
    public void DomainShouldNotDependOnAnySolutionProjects()
    {
        // Arrange
        var domain = typeof(Domain.IAssemblyMarker).Assembly;

        // Act
        var dependencies = domain.GetReferencedAssemblies()
                                 .Select(x => x.Name);

        // Assert
        dependencies.Should()
                    .NotContain(x => x.StartsWith(RootAssemblyName));
    }

    [Fact]
    public void ApplicationShouldDependOnDomain()
    {
        // Arrange
        var application = typeof(Application.IAssemblyMarker).Assembly;
        var domain = typeof(Domain.IAssemblyMarker).Assembly;

        // Act
        var domainAssemblyName = domain.GetName().Name;
        var dependencies = application.GetReferencedAssemblies()
                                      .Select(x => x.Name);

        // Assert
        dependencies.Should()
                    .Contain(x => x == domainAssemblyName);
    }

    [Fact]
    public void ApplicationShouldNotDependOnInfrastructure()
    {
        // Arrange
        var application = typeof(Application.IAssemblyMarker).Assembly;
        var infrastructure = typeof(Infrastructure.IAssemblyMarker).Assembly;

        // Act
        var domainAssemblyName = infrastructure.GetName().Name;
        var dependencies = application.GetReferencedAssemblies()
                                      .Select(x => x.Name);

        // Assert
        dependencies.Should()
                    .NotContain(x => x == domainAssemblyName);
    }

    [Fact]
    public void ApplicationShouldNotDependOnAPIs()
    {
        // Arrange
        var application = typeof(Application.IAssemblyMarker).Assembly;
        var apis = typeof(APIs.IAssemblyMarker).Assembly;

        // Act
        var domainAssemblyName = apis.GetName().Name;
        var dependencies = application.GetReferencedAssemblies()
                                      .Select(x => x.Name);

        // Assert
        dependencies.Should()
                    .NotContain(x => x == domainAssemblyName);
    }

}