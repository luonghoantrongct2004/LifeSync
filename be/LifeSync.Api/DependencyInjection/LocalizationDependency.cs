namespace LifeSync.Api.DependencyInjection;

public static class LocalizationDependency
{
    public static IServiceCollection AddLocalizationServices(this IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "Resources");
        return services;
    }
} 