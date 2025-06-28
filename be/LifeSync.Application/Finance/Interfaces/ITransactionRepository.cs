using LifeSync.Domain.Finance;
using LifeSync.Domain.Common.Enums;
using LifeSync.Application.Common.Interfaces;

namespace LifeSync.Application.Finance.Interfaces;

public interface ITransactionRepository : IBaseRepository<Transaction>
{
    Task<IEnumerable<Transaction>> GetByTypeAsync(TransactionType type);
    Task<IEnumerable<Transaction>> GetByCategoryAsync(string category);
    Task<IEnumerable<Transaction>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
} 