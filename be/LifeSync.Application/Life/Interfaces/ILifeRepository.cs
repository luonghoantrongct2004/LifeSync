using LifeSync.Domain.Life;
using LifeSync.Domain.Common.Enums;
using LifeSync.Application.Common.Interfaces;

namespace LifeSync.Application.Life.Interfaces;

public interface ILifeRepository : IBaseRepository<LifeItem>
{
    Task<IEnumerable<LifeItem>> GetByTypeAsync(LifeItemType type);
    Task<IEnumerable<LifeItem>> GetByStatusAsync(LifeItemStatus status);
    Task<IEnumerable<LifeItem>> GetByPriorityAsync(Priority priority);
    Task<IEnumerable<LifeItem>> GetByDueDateAsync(DateTime dueDate);
} 