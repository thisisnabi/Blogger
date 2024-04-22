namespace Blogger.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BloggerDbContext>(options =>
        {

            options.UseSqlServer(configuration.GetConnectionString(BloggerDbContextSchema.DefualtConnectionStringName));
        });

        services.AddTransient<IArticleRepository, ArticleRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
        services.AddTransient<ISubscruiberRepository, SubscriberRepository>();
        services.AddSingleton<ILinkGenerator, LinkGenerator>();
        services.AddSingleton<IEmailService, EmailService>();

        return services;
    }
}