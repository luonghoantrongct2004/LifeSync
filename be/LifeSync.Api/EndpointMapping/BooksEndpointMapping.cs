using LifeSync.Api.Modules.Books;

namespace LifeSync.Api.EndpointMapping;

public static class BooksEndpointMapping
{
    public static IEndpointRouteBuilder MapBooksModule(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapBookEndpoints();
        return endpoints;
    }
} 