using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Blogger.Domain.SubscriberAggregate;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Infrastructure.Persistence;
public class BloggerDbContext : DbContext
{
    public BloggerDbContext(DbContextOptions<BloggerDbContext> dbContextOptions)
            : base(dbContextOptions)
    {
        
    }

    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Subscriber> Subscribers => Set<Subscriber>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(BloggerDbContextSchema.DefaultSchema);

        var infrastructureAssembly = typeof(IAssemblyMarker).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(infrastructureAssembly); 
    }
}
