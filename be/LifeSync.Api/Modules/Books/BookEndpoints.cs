using LifeSync.Application.Books.Services;
using LifeSync.Application.Books.DTOs;
using LifeSync.Domain.Books;

namespace LifeSync.Api.Modules.Books;

public static class BookEndpoints
{
    public static void MapBookEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/books", async (BookService service) =>
        {
            var books = await service.GetAllAsync();
            return Results.Ok(books);
        });

        routes.MapGet("/api/books/{id:guid}", async (BookService service, Guid id) =>
        {
            var book = await service.GetByIdAsync(id);
            return book is not null ? Results.Ok(book) : Results.NotFound();
        });

        routes.MapPost("/api/books", async (BookService service, BookDto dto) =>
        {
            var created = await service.AddAsync(dto);
            return Results.Created($"/api/books/{created.Id}", created);
        });

        routes.MapPut("/api/books/{id:guid}", async (BookService service, Guid id, BookDto dto) =>
        {
            var updated = await service.UpdateAsync(id, dto);
            return updated ? Results.NoContent() : Results.NotFound();
        });

        routes.MapDelete("/api/books/{id:guid}", async (BookService service, Guid id) =>
        {
            var deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
} 