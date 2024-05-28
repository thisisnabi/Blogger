using Blogger.Application.Articles;
using Blogger.Application.Subscribers;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ServiceCollector.Abstractions;

namespace Blogger.Application;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services)
    {
        var application = typeof(IAssemblyMarker);
        services.AddMediatR(configure =>
        {
            configure.RegisterServicesFromAssembly(application.Assembly);
        });
        return services;
    }
}

public class DependencyManger : IServiceDiscovery
{
    public void AddServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IArticleService, ArticleService>();
        serviceCollection.AddTransient<ISubscriberService, SubscriberService>();
    }
}