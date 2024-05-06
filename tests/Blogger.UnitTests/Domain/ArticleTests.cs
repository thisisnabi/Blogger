using Blogger.Domain.ArticleAggregate;
using FluentAssertions;

namespace Blogger.UnitTests.Domain;
public class ArticleTests
{
    [Fact]
    public void CreateDraft_ShouldCreateADraft_WhenCallingCreateDraft()
    {
        // arrange
        var draft = Article.CreateDraft("hi bye", "nothing", "for what");
     
        // assert
        (draft.Status == ArticleStatus.Draft).Should().BeTrue();
    }

    [Fact]
    public void CreateArticle_ShouldCreateAnArticle_WhenCallingCreateArticle()
    {
        // arrange
        var tags = new List<Tag> { Tag.Create("aspnetcore"), Tag.Create("dotnet") };
        var article = Article.CreateArticle("hi bye", "nothing", "for what", tags);

        // assert
        (article.Status == ArticleStatus.Published).Should().BeTrue();
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
        (draft.Status == ArticleStatus.Published).Should().BeTrue();
    }

    [Fact]
    public void Publish_ShouldBeThrowDraftTagsMissingException_WhenHaventTagns()
    {
        // arrange
        var draft = Article.CreateDraft("hi bye", "nothing", "for what");
        
        // act
        var act = () => draft.Publish();

        // assert
        act.Should().Throw<DraftTagsMissingException>();
    }

}
