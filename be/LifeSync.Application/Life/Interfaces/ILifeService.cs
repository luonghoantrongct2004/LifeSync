using LifeSync.Application.Life.DTOs;

namespace LifeSync.Application.Life.Interfaces;

public interface ILifeService
{
    Task<IEnumerable<LifeItemDto>> GetAllAsync();
    Task<LifeItemDto?> GetByIdAsync(Guid id);
    Task<LifeItemDto> CreateAsync(LifeItemDto dto);
    Task<LifeItemDto?> UpdateAsync(LifeItemDto dto);
    Task<bool> DeleteAsync(Guid id);
} 