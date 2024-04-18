using MapsterMapper;

namespace Blogger.APIs;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureMapster(this IServiceCollection services)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        var applicationAssembly = AppDomain.CurrentDomain.GetAssemblies();
        typeAdapterConfig.Scan(applicationAssembly);

        services.AddSingleton(typeAdapterConfig);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
