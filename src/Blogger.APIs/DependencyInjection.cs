using System.Reflection;

namespace Blogger.APIs;

public static class DependencyInjection
{
    public static IServiceCollection ConfigurePresentationLayer(this IServiceCollection services,
                                                                IConfiguration configuration)
    {
        return services.ConfigureMapster();
    }

    private static IServiceCollection ConfigureMapster(this IServiceCollection services)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        var applicationAssembly = AppDomain.CurrentDomain.GetAssemblies();
        typeAdapterConfig.Scan(applicationAssembly);
        return services;
    }
}
