using System.ComponentModel.DataAnnotations;
using LifeSync.Domain.Common.Enums;

namespace LifeSync.Domain.Finance;

public class Transaction
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal Amount { get; set; }
    
    public TransactionType Type { get; set; } = TransactionType.Expense;
    
    [Required]
    [StringLength(50)]
    public string Category { get; set; } = string.Empty;
    
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
} 