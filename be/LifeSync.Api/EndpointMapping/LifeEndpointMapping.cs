using LifeSync.Api.Modules.Life;
using LifeSync.Application.Life.DTOs;
using LifeSync.Application.Life.Interfaces;

namespace LifeSync.Api.EndpointMapping;

public static class LifeEndpointMapping
{
    /// <summary>
    /// Maps all life-related endpoints to the application
    /// </summary>
    /// <param name="endpoints">The endpoint route builder</param>
    /// <returns>The endpoint route builder</returns>
    public static IEndpointRouteBuilder MapLifeEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/life")
            .WithTags("Life")
            .WithOpenApi();

        group.MapGet("/", async (ILifeService lifeService) =>
        {
            var items = await lifeService.GetAllAsync();
            return Results.Ok(items);
        })
        .WithName("GetAllLifeItems")
        .WithSummary("Lấy tất cả việc cần làm và mục tiêu")
        .WithDescription("Trả về danh sách tất cả các việc cần làm và mục tiêu trong hệ thống");

        group.MapGet("/{id}", async (Guid id, ILifeService lifeService) =>
        {
            var item = await lifeService.GetByIdAsync(id);
            return item != null ? Results.Ok(item) : Results.NotFound();
        })
        .WithName("GetLifeItemById")
        .WithSummary("Lấy việc cần làm theo ID")
        .WithDescription("Trả về thông tin chi tiết của một việc cần làm dựa trên ID");

        group.MapPost("/", async (LifeItemDto dto, ILifeService lifeService) =>
        {
            var createdItem = await lifeService.CreateAsync(dto);
            return Results.Created($"/api/life/{createdItem.Id}", createdItem);
        })
        .WithName("CreateLifeItem")
        .WithSummary("Tạo việc cần làm mới")
        .WithDescription("Tạo một việc cần làm hoặc mục tiêu mới trong hệ thống");

        group.MapPut("/{id}", async (Guid id, LifeItemDto dto, ILifeService lifeService) =>
        {
            dto.Id = id;
            var updatedItem = await lifeService.UpdateAsync(dto);
            return updatedItem != null ? Results.Ok(updatedItem) : Results.NotFound();
        })
        .WithName("UpdateLifeItem")
        .WithSummary("Cập nhật việc cần làm")
        .WithDescription("Cập nhật thông tin của một việc cần làm đã tồn tại");

        group.MapDelete("/{id}", async (Guid id, ILifeService lifeService) =>
        {
            var result = await lifeService.DeleteAsync(id);
            return result ? Results.NoContent() : Results.NotFound();
        })
        .WithName("DeleteLifeItem")
        .WithSummary("Xóa việc cần làm")
        .WithDescription("Xóa một việc cần làm khỏi hệ thống");

        return endpoints;
    }
} 