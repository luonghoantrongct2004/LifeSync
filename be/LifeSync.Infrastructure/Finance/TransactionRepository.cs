using LifeSync.Application.Finance.Interfaces;
using LifeSync.Domain.Finance;
using LifeSync.Domain.Common.Enums;
using LifeSync.Infrastructure.Common;
using LifeSync.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LifeSync.Infrastructure.Finance;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Transaction>> GetByTypeAsync(TransactionType type)
    {
        return await _dbSet
            .Where(t => t.Type == type)
            .OrderByDescending(t => t.TransactionDate)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Transaction>> GetByCategoryAsync(string category)
    {
        return await _dbSet
            .Where(t => t.Category == category)
            .OrderByDescending(t => t.TransactionDate)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Transaction>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate)
            .OrderByDescending(t => t.TransactionDate)
            .AsNoTracking()
            .ToListAsync();
    }
} 