using LifeSync.Application.Life.DTOs;
using LifeSync.Application.Life.Interfaces;
using LifeSync.Domain.Life;
using LifeSync.Domain.Common.Enums;

namespace LifeSync.Application.Life.Services;

public class LifeService : ILifeService
{
    private readonly ILifeRepository _lifeRepository;

    public LifeService(ILifeRepository lifeRepository)
    {
        _lifeRepository = lifeRepository;
    }

    public async Task<IEnumerable<LifeItemDto>> GetAllAsync()
    {
        var items = await _lifeRepository.GetAllAsync();
        return items.Select(MapToDto);
    }

    public async Task<LifeItemDto?> GetByIdAsync(Guid id)
    {
        var item = await _lifeRepository.GetByIdAsync(id);
        return item != null ? MapToDto(item) : null;
    }

    public async Task<LifeItemDto> CreateAsync(LifeItemDto dto)
    {
        var entity = new LifeItem
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            Type = Enum.Parse<LifeItemType>(dto.Type),
            Status = Enum.Parse<LifeItemStatus>(dto.Status),
            Priority = Enum.Parse<Priority>(dto.Priority),
            CreatedAt = DateTime.UtcNow
        };

        var createdItem = await _lifeRepository.AddAsync(entity);
        return MapToDto(createdItem);
    }

    public async Task<LifeItemDto?> UpdateAsync(LifeItemDto dto)
    {
        var existingItem = await _lifeRepository.GetByIdAsync(dto.Id);
        if (existingItem == null)
            return null;

        existingItem.Title = dto.Title;
        existingItem.Description = dto.Description;
        existingItem.Type = Enum.Parse<LifeItemType>(dto.Type);
        existingItem.Status = Enum.Parse<LifeItemStatus>(dto.Status);
        existingItem.Priority = Enum.Parse<Priority>(dto.Priority);
        existingItem.UpdatedAt = DateTime.UtcNow;

        var updatedItem = await _lifeRepository.UpdateAsync(existingItem);
        return MapToDto(updatedItem);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _lifeRepository.DeleteAsync(id);
    }

    private static LifeItemDto MapToDto(LifeItem entity)
    {
        return new LifeItemDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Type = entity.Type.ToString(),
            Status = entity.Status.ToString(),
            Priority = entity.Priority.ToString(),
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }
} 