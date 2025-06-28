using LifeSync.Application.Finance.DTOs;
using LifeSync.Application.Finance.Interfaces;
using LifeSync.Domain.Finance;

namespace LifeSync.Application.Finance.Services;

public class TransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IEnumerable<TransactionDto>> GetAllAsync()
    {
        var transactionEntities = await _transactionRepository.GetAllAsync();
        return transactionEntities.Select(transactionEntity => new TransactionDto
        {
            Id = transactionEntity.Id,
            Amount = transactionEntity.Amount,
            Description = transactionEntity.Description,
            Date = transactionEntity.TransactionDate,
            Category = transactionEntity.Category
        });
    }

    public async Task<TransactionDto?> GetByIdAsync(Guid id)
    {
        var transactionEntity = await _transactionRepository.GetByIdAsync(id);
        if (transactionEntity == null) return null;
        return new TransactionDto
        {
            Id = transactionEntity.Id,
            Amount = transactionEntity.Amount,
            Description = transactionEntity.Description,
            Date = transactionEntity.TransactionDate,
            Category = transactionEntity.Category
        };
    }

    public async Task<TransactionDto> AddAsync(TransactionDto transactionDto)
    {
        var transactionEntity = new Transaction
        {
            Id = Guid.NewGuid(),
            Amount = transactionDto.Amount,
            Description = transactionDto.Description,
            TransactionDate = transactionDto.Date,
            Category = transactionDto.Category
        };
        await _transactionRepository.AddAsync(transactionEntity);
        return new TransactionDto
        {
            Id = transactionEntity.Id,
            Amount = transactionEntity.Amount,
            Description = transactionEntity.Description,
            Date = transactionEntity.TransactionDate,
            Category = transactionEntity.Category
        };
    }

    public async Task<bool> UpdateAsync(Guid id, TransactionDto transactionDto)
    {
        var transactionEntity = await _transactionRepository.GetByIdAsync(id);
        if (transactionEntity == null) return false;
        transactionEntity.Amount = transactionDto.Amount;
        transactionEntity.Description = transactionDto.Description;
        transactionEntity.TransactionDate = transactionDto.Date;
        transactionEntity.Category = transactionDto.Category;
        await _transactionRepository.UpdateAsync(transactionEntity);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var transactionEntity = await _transactionRepository.GetByIdAsync(id);
        if (transactionEntity == null) return false;
        await _transactionRepository.DeleteAsync(id);
        return true;
    }
} 