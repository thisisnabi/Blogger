using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Blogger.Domain.SubscriberAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Blogger.Infrastructure.Persistence;
public class BloggerDbContextFactory : IDesignTimeDbContextFactory<BloggerDbContext>
{
    public BloggerDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<BloggerDbContext>();
        optionBuilder.UseSqlServer("data source=.;initial catalog=thisisnabi.blogger;TrustServerCertificate=True;Trusted_Connection=True;");

        return new BloggerDbContext(optionBuilder.Options);
    }
}
