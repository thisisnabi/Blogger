using Blogger.Application.ApplicationServices;

using ServiceCollector.Abstractions;

namespace Blogger.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));

        services.AddDbContext<BloggerDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(BloggerDbContextSchema.DefualtConnectionStringName));
        });
        return services;
    }
}

public class DependencyManager : IServiceDiscovery
{
    public void AddServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IArticleRepository, ArticleRepository>();
        serviceCollection.AddTransient<ICommentRepository, CommentRepository>();
        serviceCollection.AddTransient<ISubscriberRepository, SubscriberRepository>();
        serviceCollection.AddSingleton<ILinkGenerator, LinkGenerator>();
        serviceCollection.AddSingleton<IEmailService, EmailService>();
    }
}