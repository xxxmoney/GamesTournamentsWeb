using GamesTournamentsWeb.Infrastructure.Ioc;
using GamesTournamentsWeb.Tests.Helpers.Mock;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GamesTournamentsWeb.Tests.Helpers;

public static class DependencyResolverHelper
{
    private const string DEV = "appsettings.Development.json";
    private const string PROD = "appsettings.json";
        
    public enum Environment { DEV, PROD }
        
    private static IServiceProvider GetServiceProvider(Environment environment)
    {
        string environmentValue = environment switch
        {
            Environment.DEV => DEV,
            Environment.PROD => PROD,
            _ => throw new NotImplementedException()
        };
            
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(environmentValue, optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        IConfiguration config = builder.Build();

        var services = DependencyResolver.ConfigureServices(new ServiceCollection(), config);
        services.AddSingleton(config);
        services.AddSingleton<IHostEnvironment>(new MockHostEnvironment(environment));

        return services.BuildServiceProvider();
    }

    public static T GetService<T>(Environment environment = Environment.DEV)
        where T : notnull
    {
        return GetServiceProvider(environment).GetRequiredService<T>();
    }
}