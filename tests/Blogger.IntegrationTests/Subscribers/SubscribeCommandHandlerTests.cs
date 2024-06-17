using Blogger.Application.Subscribers;
using Blogger.Application.Subscribers.Subscribe;
using Blogger.Domain.SubscriberAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

namespace Blogger.IntegrationTests.Subscribers;
public class SubscribeCommandHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public SubscribeCommandHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_DuplicateSubscriber_ShouldThrowDuplicateSubscriptionException()
    {
        // Arrange
        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());
        var subscribeRepository = new SubscriberRepository(dbContext);

        var subscriberId = SubscriberId.CreateUniqueId("thisisnabi@dev.com");
        var subscriber = Subscriber.Create(subscriberId);
        await subscribeRepository.CreateAsync(subscriber, CancellationToken.None);
        await subscribeRepository.SavaChangesAsync(CancellationToken.None);

        var subscriberService = new SubscriberService(subscribeRepository);

        var sut = new SubscribeCommandHandler(subscribeRepository, subscriberService);

        var command = new SubscribeCommand(subscriberId);

        // Act
        Func<Task> act = async () => await sut.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<DuplicateSubscribtionException>();
    }

    [Fact]
    public async Task Handle_NewSubscriber_ShouldCreateSubscriberAndSaveChanges()
    {
        // Arrange
        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());
        var subscribeRepository = new SubscriberRepository(dbContext);

        var subscriberId = SubscriberId.CreateUniqueId("thisisnabi@dev.com");

        var subscriberService = new SubscriberService(subscribeRepository);

        var sut = new SubscribeCommandHandler(subscribeRepository, subscriberService);

        var command = new SubscribeCommand(subscriberId);

        // Act
        await sut.Handle(command, CancellationToken.None);

        // Assert
        var subscriber = await subscribeRepository.FindByIdAsync(subscriberId);
        subscriber.Should().NotBeNull();
    }
}
