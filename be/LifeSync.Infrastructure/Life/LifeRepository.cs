using LifeSync.Application.Life.Interfaces;
using LifeSync.Domain.Life;
using LifeSync.Domain.Common.Enums;
using LifeSync.Infrastructure.Common;
using LifeSync.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LifeSync.Infrastructure.Life;

public class LifeRepository : BaseRepository<LifeItem>, ILifeRepository
{
    public LifeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<LifeItem>> GetByTypeAsync(LifeItemType type)
    {
        return await _dbSet
            .Where(item => item.Type == type)
            .OrderByDescending(item => item.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<LifeItem>> GetByStatusAsync(LifeItemStatus status)
    {
        return await _dbSet
            .Where(item => item.Status == status)
            .OrderByDescending(item => item.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<LifeItem>> GetByPriorityAsync(Priority priority)
    {
        return await _dbSet
            .Where(item => item.Priority == priority)
            .OrderByDescending(item => item.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<LifeItem>> GetByDueDateAsync(DateTime dueDate)
    {
        return await _dbSet
            .Where(item => item.DueDate.HasValue && item.DueDate.Value.Date == dueDate.Date)
            .OrderBy(item => item.Priority)
            .ThenBy(item => item.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }
} 