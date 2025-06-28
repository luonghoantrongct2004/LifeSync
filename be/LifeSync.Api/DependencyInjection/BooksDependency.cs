using LifeSync.Application.Books.Interfaces;
using LifeSync.Application.Books.Services;
using LifeSync.Infrastructure.Books;

namespace LifeSync.Api.DependencyInjection;

public static class BooksDependency
{
    public static IServiceCollection AddBookServices(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<BookService>();
        return services;
    }
} 