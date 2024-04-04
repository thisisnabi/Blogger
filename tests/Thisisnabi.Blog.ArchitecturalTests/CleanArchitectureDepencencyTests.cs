using NetArchTest.Rules;
using Xunit.Abstractions;

namespace Thisisnabi.Blog.ArchitecturalTests;

public class CleanArchitectureDepencencyTests
{
    private readonly ITestOutputHelper _console;
    public CleanArchitectureDepencencyTests(ITestOutputHelper console)
    {
        _console = console;
    }

    [Fact]
    public void Domain_ShouldNotHaveDependencyOnOtherProjects()
    {
        // arrange
        var assembly = typeof(Domain.Common.IAssemblyMarker).Assembly;

        // act
        var result = Types.InAssembly(assembly)
                          .Should()
                          .NotHaveDependencyOn("Thisisnabi.Blog.Application")
                          .And()                
                          .NotHaveDependencyOn("Thisisnabi.Blog.APIs")
                          .And()                
                          .NotHaveDependencyOn("Thisisnabi.Blog.Infrastructure")
                          .GetResult();
         
        // assert
        Assert.True(result.IsSuccessful);
    }


    [Fact]
    public void Application_ShouldNotHaveDependencyOnOtherProjects()
    {
        // arrange
        var assembly = typeof(Application.Common.IAssemblyMarker).Assembly;

        // act
        var result = Types.InAssembly(assembly)
                          .Should()
                          .HaveDependencyOn("Thisisnabi.Blog.Domain")
                          .And()
                          .NotHaveDependencyOn("Thisisnabi.Blog.APIs")
                          .And()
                          .NotHaveDependencyOn("Thisisnabi.Blog.Infrastructure")
                          .GetResult();

        // assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Infrastructure_ShouldNotHaveDependencyOnOtherProjects()
    {
        // arrange
        var assembly = typeof(Infrastructure.Common.IAssemblyMarker).Assembly;

        // act
        var result = Types.InAssembly(assembly)
                          .Should()
                          .HaveDependencyOn("Thisisnabi.Blog.Application")
                          .And()
                          .NotHaveDependencyOn("Thisisnabi.Blog.APIs")
                          .GetResult();

        // assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void APIs_ShouldNotHaveDependencyOnOtherProjects()
    {
        // arrange
        var assembly = typeof(APIs.Common.IAssemblyMarker).Assembly;
        
        // act
        var result = Types.InAssembly(assembly)
                          .Should()
                          .HaveDependencyOn("Thisisnabi.Blog.Application")
                          .And()
                          .NotHaveDependencyOn("Thisisnabi.Blog.Infrastructure")
                          .GetResult();

        // assert
        Assert.True(result.IsSuccessful);
    }
}