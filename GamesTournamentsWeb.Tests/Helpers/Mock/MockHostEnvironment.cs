using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace GamesTournamentsWeb.Tests.Helpers.Mock;

public class MockHostEnvironment(DependencyResolverHelper.Environment environment) : IHostEnvironment
{
    public string EnvironmentName { get; set; } = environment switch
    {
        DependencyResolverHelper.Environment.DEV => Environments.Development,
        DependencyResolverHelper.Environment.PROD => Environments.Production,
        _ => throw new NotImplementedException()
    };

    public string ApplicationName { get; set; }
    public string ContentRootPath { get; set; }
    public IFileProvider ContentRootFileProvider { get; set; }
    public string WebRootPath { get; set; }
    public IFileProvider WebRootFileProvider { get; set; }
}