using LifeSync.Application.Life.Interfaces;
using LifeSync.Application.Life.Services;
using LifeSync.Infrastructure.Life;

namespace LifeSync.Api.DependencyInjection;

public static class LifeDependency
{
    public static IServiceCollection AddLifeServices(this IServiceCollection services)
    {
        services.AddScoped<ILifeRepository, LifeRepository>();
        services.AddScoped<ILifeService, LifeService>();
        
        return services;
    }
} 