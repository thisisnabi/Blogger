using Blogger.Domain.ArticleAggregate;

using FluentAssertions;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Blogger.UnitTests.Domain.Articles;
public class ArticleTests
{
    [Fact]
    public void CreateDraft_ShouldCreateADraft_WhenCallingCreateDraft()
    {
        // arrange
        var draft = Article.CreateDraft("Linq Improvements in .NET 9!","Just for funny.","Hello...");

        // assert
        draft.Should().NotBeNull();
        draft.Author.Should().NotBeNull();
        draft.Status.Should().Be(ArticleStatus.Draft);
    }

    [Fact]
    public void CreateArticle_ShouldCreateAnArticle_WhenCallingCreateArticle()
    {
        // arrange
        var tags = new List<Tag> { Tag.Create("aspnetcore"), Tag.Create("dotnet") };
        var article = Article.CreateArticle("hi bye", "nothing", "for what", tags);

        // assert
        article.Should().NotBeNull();
        article.Author.Should().NotBeNull();
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
        draft.PublishedOnUtc.Should().Be(DateTime.UtcNow);
        // TODO: here we must be test ReadOn timespan
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

}
