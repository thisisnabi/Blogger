using AutoFixture;
using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.Common;
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
        author.Should().BeAssignableTo<ValueObject<Author>>("type of author object is not ValueObject");
        AssertAuthorProperties(author,new AuthorTestDto(fullName,avatar,jobTitle));

    }

    [Theory]
    [InlineData("", "avatar", "jobTitle")]
    [InlineData("fullName", "", "jobTitle")]
    [InlineData("fullName", "avatars", "")]
    [InlineData(" ", "avatar", "jobTitle")]
    [InlineData("fullName", " ", "jobTitle")]
    [InlineData("fullName", "avatars", " ")]
    public void Create_GivenSomeInCorrectParameters_ThrowArgumentException(string fullName, string avatar,
        string jobTitle)
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
        AssertAuthorProperties(author,new AuthorTestDto(expectedFullName,expectedAvatar,expectedJobTitle));
    }

    private static void AssertAuthorProperties(Author author, AuthorTestDto authorTestDto)
    {
        author.Avatar.Should().Be(authorTestDto.Avatar, "avatar is not correct");
        author.FullName.Should().Be(authorTestDto.FullName, "fullName is not correct");
        author.JobTitle.Should().Be(authorTestDto.JobTitle, "jobName is not correct");
    }

    private class AuthorTestDto
    {
        internal AuthorTestDto(string fullName, string avatar, string jobTitle)
        {
            FullName = fullName;
            Avatar = avatar;
            JobTitle = jobTitle;
        }

        internal string FullName { get; }

        internal string Avatar { get; }

        internal string JobTitle { get; }
    }
}