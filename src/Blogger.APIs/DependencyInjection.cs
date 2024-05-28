using Microsoft.Extensions.DependencyInjection.Extensions;

using ServiceCollector.Abstractions;

namespace Blogger.APIs;

public class AddMapster : IServiceDiscovery
{
    private readonly static Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();

    public void AddServices(IServiceCollection serviceCollection)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(Assemblies);

        serviceCollection.AddSingleton(typeAdapterConfig);
        serviceCollection.AddScoped<IMapper, ServiceMapper>();
    }
}

public class AddValidator : IServiceDiscovery
{
    private readonly static Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();

    public void AddServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddValidatorsFromAssemblies(Assemblies);
    }
}

public class AddCors : IServiceDiscovery
{
    public void AddServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddCors(options =>
        {
            options.AddPolicy(name: "AllowOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
    }
}

public class AddEndpoint : IServiceDiscovery
{
    public void AddServices(IServiceCollection serviceCollection)
    {
        var assembly = typeof(IAssemblyMarker).Assembly;

        ServiceDescriptor[] serviceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();

        serviceCollection.TryAddEnumerable(serviceDescriptors);
    }
}

public static class DependencyInjection
{
    public static IApplicationBuilder MapEndpoints(this WebApplication app)
    {
        IEnumerable<IEndpoint> endpoints = app.Services
            .GetRequiredService<IEnumerable<IEndpoint>>();

        foreach (IEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(app);
        }

        return app;
    }
}