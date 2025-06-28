using LifeSync.Application.Finance.Interfaces;
using LifeSync.Application.Finance.Services;
using LifeSync.Infrastructure.Finance;

namespace LifeSync.Api.DependencyInjection;

public static class FinanceDependency
{
    public static IServiceCollection AddFinanceServices(this IServiceCollection services)
    {
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<TransactionService>();
        return services;
    }
} 