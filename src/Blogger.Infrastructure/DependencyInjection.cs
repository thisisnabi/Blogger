using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Blogger.Domain.SubscriberAggregate;
using Blogger.Infrastructure.Persistence;
using Blogger.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blogger.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BloggerDbContext>(options => {

            options.UseSqlServer(configuration.GetConnectionString(BloggerDbContextSchema.DefualtConnectionStringName));
        });

        services.AddTransient<IArticleRepository, ArticleRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
        services.AddTransient<ISubscruiberRepository, SubscriberRepository>();

        return services;
    }
}