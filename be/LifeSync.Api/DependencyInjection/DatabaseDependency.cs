using LifeSync.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LifeSync.Api.DependencyInjection;

public static class DatabaseDependency
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("Postgres")));
        return services;
    }
} 