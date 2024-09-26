using Microsoft.EntityFrameworkCore.Design;

namespace Blogger.Infrastructure.Persistence;
public class BloggerDbContextFactory : IDesignTimeDbContextFactory<BloggerDbContext>
{
    public BloggerDbContextFactory(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public IServiceProvider ServiceProvider { get; }

    public BloggerDbContext CreateDbContext(string[] args)
    {
        return ServiceProvider.GetRequiredService<BloggerDbContext>();
    }
}
