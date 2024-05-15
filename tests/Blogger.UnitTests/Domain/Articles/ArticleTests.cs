using Blogger.Domain.ArticleAggregate;

using FluentAssertions;

namespace Blogger.UnitTests.Domain.Articles;
public class ArticleTests
{
    [Fact]
    public void CreateDraft_ShouldCreateADraft_WhenCallingCreateDraft()
    {
        // act
        Article draft = ArticleBuilder.CreateBuilder()
                                        .BuildDraft();

        // assert
        draft.Should().NotBeNull();
        draft.Author.Should().NotBeNull();
        draft.Status.Should().Be(ArticleStatus.Draft);
    }

    [Fact]
    public void CreateArticle_ShouldCreateAnArticle_WhenCallingCreateArticle()
    {
        // act
        Article article = ArticleBuilder.CreateBuilder()
                                        .Build();

        // assert
        article.Should().NotBeNull();
        article.Author.Should().NotBeNull();
        article.Status.Should().Be(ArticleStatus.Published);
    }

    [Fact]
    public void Publish_ShouldMakeArticle_WhenHaveDraft()
    {
        // act
        Article draft = ArticleBuilder.CreateBuilder()
                                      .SetTitle("hi bye")
                                      .SetBody("nothing")
                                      .SetSummary("for what")
                                      .SetTag([Tag.Create("aspnetcore"), Tag.Create("dotnet")])
                                      .SetReadOn(new TimeSpan(20))
                                      .Build();
        draft.Publish();

        // assert
        draft.Status.Should().Be(ArticleStatus.Published);
        // TODO: here we must be test ReadOn timespan
    }

    [Fact]
    public void Publish_ShouldThrowDraftTagsMissingException_WhenDoesntHaveTags()
    {

        // act
        var act = () => ArticleBuilder.CreateBuilder()
                                        .BuildDraft()
                                        .Publish();

        // assert
        act.Should().Throw<DraftTagsMissingException>();
    }
}