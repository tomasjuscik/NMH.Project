namespace Flowio.Core.API;

using NMH.Project.Api;
using NMH.Project.Infrastructure.Data;

public static class Program
{
    public static void Main(string[] args)
        => CreateHostBuilder(args)
            .Build()
            .InitializeDB()
            .Run();

    public static IHostBuilder CreateHostBuilder(string[] args)
        => Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}

public static class HostExtensions
{
    public static IHost InitializeDB(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var dbInit = scope.ServiceProvider.GetRequiredService<DbInit>();
        dbInit.Run();
        return host;
    }
}