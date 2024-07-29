namespace NMH.Project.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NMH.Project.Application.Core.Abstraction;
using NMH.Project.Infrastructure.Data;
using NMH.Project.Infrastructure.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<NMHProjectDbContext>(o => o.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<DbInit>();
        services.AddSingleton<IKeyValueStorageService, KeyValueStorageService>();
        return services;
    }
}