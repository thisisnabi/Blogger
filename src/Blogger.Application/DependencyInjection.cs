using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blogger.Application;
public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var application = typeof(IAssemblyMarker);
         
        services.AddMediatR(configure =>
        {
            configure.RegisterServicesFromAssembly(application.Assembly);
        });
        services.AddMapster();
        return services;
    }
    private static IServiceCollection AddMapster(this IServiceCollection services)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        var applicationAssembly = Assembly.GetExecutingAssembly();
        typeAdapterConfig.Scan(applicationAssembly);
        return services;
    }

}
