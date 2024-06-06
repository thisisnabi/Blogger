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
        actual.Should().BeAssignableTo<ValueObject<Author>>();
        actual.Avatar.Should().Be(avatar);
        actual.FullName.Should().Be(fullName);
        actual.JobTitle.Should().Be(jobTitle);
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
        const string expectedAvatar = "https://avatars.githubusercontent.com/u/3371886?s=400&u=cb8ebf9fc27e463b5d7002aaeeef881eb950b71f&v=4";

        // Act
        var actual = Author.CreateDefaultAuthor();

        // Assert
        actual.Avatar.Should().Be(expectedAvatar);
        actual.FullName.Should().Be(expectedFullName);
        actual.JobTitle.Should().Be(expectedJobTitle);
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