using Blogger.BuildingBlocks.Exceptions;

using Blogger.Domain.SubscriberAggregate;

using FluentAssertions;

namespace Blogger.UnitTests.Domain.ArticleAggregateTests;
public class SubscriberIdTests
{
    [Fact]

    public void CreateUniqeId_ShouldThrowInvalidEmailAddressException_WhenHaveIncorrectEmail()
    {
        // act
        var func = () => SubscriberId.CreateUniqueId("invalidData");

        // assert
        func.Should().Throw<InvalidEmailAddressException>();
    }

    [Theory]
    [InlineData("thisisnabi.dev@gmail.com")]
    [InlineData("iman.safari@gmail.com")]
    public void CreateUniqeId_ShouldReturnSubscriberId_WhenHaveCorrectEmail(string emailAddress)
    {
        // arrange
        var subId = SubscriberId.CreateUniqueId(emailAddress);

        // assert
        subId.Should().NotBeNull();
        subId.Email.Address.Should().Be(emailAddress);
    }

}
