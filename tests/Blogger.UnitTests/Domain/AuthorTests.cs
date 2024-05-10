using AutoFixture;
using Blogger.Domain.ArticleAggregate;
using FluentAssertions;

namespace Blogger.UnitTests.Domain;

public class AuthorTests : IClassFixture<BaseFixture>
{
    private readonly BaseFixture _baseFixture;

    public AuthorTests(BaseFixture baseFixture)
    {
        _baseFixture = baseFixture;
    }

    [Fact]
    public void Create_GivenSomeValidParameters_AuthorObjectCreatedSuccessfully()
    {
        // Arrange
        var fullName = _baseFixture.Fixture.Create<string>();
        var avatar = _baseFixture.Fixture.Create<string>();
        var jobTitle = _baseFixture.Fixture.Create<string>();

        // Act
        var author = Author.Create(fullName, avatar, jobTitle);

        // Assert
        author.Should().NotBeNull("author object is null");
        author.Should().BeAssignableTo<Author>("type of author object is not AuthorType");
        author.Avatar.Should().Be(avatar, "avatar is not correct");
        author.FullName.Should().Be(fullName, "fullName is not correct");
        author.JobTitle.Should().Be(jobTitle, "jobName is not correct");
    }

    [Theory]
    [InlineData("", "avatar","jobTitle")]
    [InlineData("fullName", "","jobTitle")]
    [InlineData("fullName", "avatars","")]
    
    [InlineData(" ", "avatar","jobTitle")]
    [InlineData("fullName", " ","jobTitle")]
    [InlineData("fullName", "avatars"," ")]
    public void Create_GivenSomeInCorrectParameters_ThrowArgumentException(string fullName, string avatar, string jobTitle)
    {
        // Arrange
        // Act
        Action action = () => Author.Create(fullName, avatar, jobTitle);

        // Assert
        action.Should().Throw<ArgumentException>("parameters are incorrect but did not throw Exception");
    }
    
    [Fact]
    public void CreateDefaultAuthor_withoutAnyParameters_AuthorObjectCreatedSuccessfullyWithDefaultValues()
    {
        // Arrange
        const string expectedFullName = "Nabi Karampour";
        const string expectedJobTitle = "Senior Software Engineer";
        const string expectedAvatar = "/images/avatars/thisisnabi.png";

        // Act
        var author = Author.CreateDefaultAuthor();

        // Assert
        author.Avatar.Should().Be(expectedAvatar, "avatar is not correct");
        author.FullName.Should().Be(expectedFullName, "fullName is not correct");
        author.JobTitle.Should().Be(expectedJobTitle, "jobName is not correct");
    }
} 