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
    public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BloggerDbContext>(options => {

            options.UseSqlServer(configuration.GetConnectionString(BloggerDbContextSchema.DefualtConnectionStringName));
        });

        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ISubscruiberRepository, SubscriberRepository>();

        return services;
    }
}