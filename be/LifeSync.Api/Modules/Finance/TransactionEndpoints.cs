using LifeSync.Application.Finance.Services;
using LifeSync.Application.Finance.DTOs;

namespace LifeSync.Api.Modules.Finance;

public static class TransactionEndpoints
{
    public static void MapTransactionEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/transactions", async (TransactionService service) =>
        {
            var items = await service.GetAllAsync();
            return Results.Ok(items);
        });

        routes.MapGet("/api/transactions/{id:guid}", async (TransactionService service, Guid id) =>
        {
            var item = await service.GetByIdAsync(id);
            return item is not null ? Results.Ok(item) : Results.NotFound();
        });

        routes.MapPost("/api/transactions", async (TransactionService service, TransactionDto dto) =>
        {
            var created = await service.AddAsync(dto);
            return Results.Created($"/api/transactions/{created.Id}", created);
        });

        routes.MapPut("/api/transactions/{id:guid}", async (TransactionService service, Guid id, TransactionDto dto) =>
        {
            var updated = await service.UpdateAsync(id, dto);
            return updated ? Results.NoContent() : Results.NotFound();
        });

        routes.MapDelete("/api/transactions/{id:guid}", async (TransactionService service, Guid id) =>
        {
            var deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
} 