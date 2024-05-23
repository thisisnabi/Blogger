using Blogger.BuildingBlocks.Domain;
using Blogger.Domain.ArticleAggregate;

using FluentAssertions;

namespace Blogger.UnitTests.Domain.ArticleAggregateTests;

public class AuthorTests
{
    [Fact]
    public void Create_GivenSomeValidParameters_AuthorObjectCreatedSuccessfully()
    {
        // Arrange
        var fullName = "Nabi Karampour";
        var avatar = "../../images/thisisnabi.png";
        var jobTitle = "Software Developer";

        // Act
        var actual = Author.Create(fullName, avatar, jobTitle);

        // Assert
        actual.Should().BeAssignableTo<ValueObject<Author>>("type is not ValueObject");
        AssertAuthorProperties(actual, new AuthorTestDto(fullName, avatar, jobTitle));

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
        Action actual = () => Author.Create(fullName, avatar, jobTitle);

        // Assert
        actual.Should().Throw<ArgumentException>("parameters are incorrect but did not throw Exception");
    }

    [Fact]
    public void CreateDefaultAuthor_withoutAnyParameters_AuthorObjectCreatedSuccessfullyWithDefaultValues()
    {
        // Arrange
        const string expectedFullName = "Nabi Karampour";
        const string expectedJobTitle = "Senior Software Engineer";
        const string expectedAvatar = "/images/avatars/thisisnabi.png";

        // Act
        var actual = Author.CreateDefaultAuthor();

        // Assert
        AssertAuthorProperties(actual, new AuthorTestDto(expectedFullName, expectedAvatar, expectedJobTitle));
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