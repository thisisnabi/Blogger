using Blogger.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Blogger.IntegrationTests.Fixtures;

public class BloggerDbContextFixture : EfDatabaseBaseFixture<BloggerDbContext>
{
    public BloggerDbContextFixture(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public IServiceProvider ServiceProvider { get; }

    protected override BloggerDbContext BuildDbContext(DbContextOptions<BloggerDbContext> options)
    {
        return ServiceProvider.GetRequiredService<BloggerDbContext>();
    }
}