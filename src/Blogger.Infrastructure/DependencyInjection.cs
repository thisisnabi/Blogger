using Blogger.Application.ApplicationServices;

namespace Blogger.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));

        services.AddDbContext<BloggerDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(BloggerDbContextSchema.DefaultConnectionStringName));
        });

        services.AddTransient<IArticleRepository, ArticleRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
        services.AddTransient<ISubscriberRepository, SubscriberRepository>();
        services.AddSingleton<ILinkGenerator, LinkGenerator>();
        services.AddSingleton<IEmailService, EmailService>();

        return services;
    }
}