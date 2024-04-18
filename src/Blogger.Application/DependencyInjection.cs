using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blogger.Application;
public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ILinkGenerator, LinkGenerator>();
        services.AddTransient<IArticleService, ArticleService>();
        services.AddTransient<ISubscriberService, SubscriberService>();

        var application = typeof(IAssemblyMarker);

        services.AddMediatR(configure =>
        {
            configure.RegisterServicesFromAssembly(application.Assembly);
        });
        return services;
    }
}