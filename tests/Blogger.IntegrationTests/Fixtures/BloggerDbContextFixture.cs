using Blogger.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Blogger.IntegrationTests.Fixtures;

public class BloggerDbContextFixture : EfDatabaseBaseFixture<BloggerDbContext>
{
    protected override BloggerDbContext BuildDbContext(DbContextOptions<BloggerDbContext> options)
    {
        return new BloggerDbContext(options);
    }
}