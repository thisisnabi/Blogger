using Blogger.Domain.ArticleAggregate;

using FluentAssertions;

using static Blogger.Infrastructure.Persistence.BloggerDbContextSchema;

namespace Blogger.UnitTests.Domain.ArticleAggregateTests;
public class ArticleTests
{
    [Fact]
    public void CreateDraft_ShouldCreateADraft_WhenCallingCreateDraft()
    {
        // arrange
        var draft = Article.CreateDraft("hi bye", "nothing", "for what");

        // assert
        draft.Status.Should().Be(ArticleStatus.Draft);
    }

    [Fact]
    public void CreateArticle_ShouldCreateAnArticle_WhenCallingCreateArticle()
    {
        // arrange
        var tags = new List<Tag> { Tag.Create("aspnetcore"), Tag.Create("dotnet") };
        var article = Article.CreateArticle("hi bye", "nothing", "for what", tags);

        // assert
        article.Status.Should().Be(ArticleStatus.Published);
    }

    [Fact]
    public void Publish_ShouldMakeArticle_WhenHaveDraft()
    {
        // arrange
        var draft = Article.CreateDraft("hi bye", "nothing", "for what");
        draft.AddTags(new List<Tag> { Tag.Create("aspnetcore"), Tag.Create("dotnet") });

        // act
        draft.Publish();

        // assert
        draft.Status.Should().Be(ArticleStatus.Published);
    }

    [Fact]
    public void Publish_ShouldThrowDraftTagsMissingException_WhenDoesntHaveTags()
    {
        // arrange
        var draft = Article.CreateDraft("hi bye", "nothing", "for what");

        // act
        var act = () => draft.Publish();

        // assert
        act.Should().Throw<DraftTagsMissingException>();
    }

    [Fact]
    public void GetReadOnTimeSpan_ShouldReturnZero_ForEmptyString()
    {
        // Arrange
        var tags = new List<Tag> { Tag.Create("aspnetcore"), Tag.Create("dotnet") };
        var body = string.Empty;
        var article = Article.CreateArticle("hi bye", body, "for what", tags);

        // Act
        var result = article.ReadOn;

        // Assert
        result.Should().Be(TimeSpan.Zero);
    }

    [Fact]
    public void GetReadOnTimeSpan_ShouldReturnZero_ForWhitespaceString()
    {
        // Arrange
        var tags = new List<Tag> { Tag.Create("aspnetcore"), Tag.Create("dotnet") };
        var body = "   ";
        var article = Article.CreateArticle("hi bye", body, "for what", tags);

        // Act
        var result = article.ReadOn;

        // Assert
        result.Should().Be(TimeSpan.Zero);
    }

    [Fact]
    public void GetReadOnTimeSpan_ShouldCalculateCorrectTime_ForShortText()
    {
        // Arrange
        var tags = new List<Tag> { Tag.Create("aspnetcore"), Tag.Create("dotnet") };
        var body = "This is a short text.";
        var article = Article.CreateArticle("hi bye", body, "for what", tags);

        // Act
        var result = article.ReadOn;

        // Assert
        var expectedTime = TimeSpan.FromMinutes(1.0 / 200.0 * 5);
        result.Should().BeCloseTo(expectedTime, precision: TimeSpan.FromSeconds(1));
    }

    private static readonly Random Random = new Random();

    private static string GenerateRandomWords(int wordCount)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        return string.Join(" ", Enumerable.Range(1, wordCount).Select(_ => new string(Enumerable.Repeat(chars, Random.Next(1, 10)).Select(s => s[Random.Next(s.Length)]).ToArray())));
    }


    [Theory]
    [InlineData(200, 1)]
    [InlineData(1000, 5)]
    [InlineData(5000, 25)]
    public void GetReadOnTimeSpan_ShouldCalculateCorrectTime_For200Words(int wordCount, int expectedTime)
    {
        // Arrange
        var tags = new List<Tag> { Tag.Create("aspnetcore"), Tag.Create("dotnet") };
        var body = GenerateRandomWords(wordCount);
        var article = Article.CreateArticle("hi bye", body, "for what", tags);

        // Act
        var result = article.ReadOn;
        // Assert

        result.Should().BeCloseTo(TimeSpan.FromMinutes(expectedTime), precision: TimeSpan.FromSeconds(1));
    }
}
