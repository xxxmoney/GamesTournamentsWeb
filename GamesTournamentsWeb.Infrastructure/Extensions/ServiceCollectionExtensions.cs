using Microsoft.Extensions.DependencyInjection;

namespace GamesTournamentsWeb.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterInheritedFromType(this IServiceCollection services, Type inheritFromType, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        var assembly = inheritFromType.Assembly;
        var types = assembly.GetTypes()
            .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Any(i => i == inheritFromType));
        foreach (var concreteType in types)
        {
            var concreteInterfaceType = concreteType.GetInterfaces().First(i => i != inheritFromType);
            
            switch (lifetime)
            {
                case ServiceLifetime.Transient:
                    services.AddTransient(concreteInterfaceType, concreteType);
                    break;
                case ServiceLifetime.Singleton:
                    services.AddSingleton(concreteInterfaceType, concreteType);
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped(concreteInterfaceType, concreteType);
                    break;
            }
        }
    }
}