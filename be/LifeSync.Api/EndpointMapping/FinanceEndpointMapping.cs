using LifeSync.Api.Modules.Finance;

namespace LifeSync.Api.EndpointMapping;

public static class FinanceEndpointMapping
{
    public static IEndpointRouteBuilder MapFinanceModule(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapTransactionEndpoints();
        return endpoints;
    }
} 