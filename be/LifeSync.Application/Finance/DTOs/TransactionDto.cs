namespace LifeSync.Application.Finance.DTOs;

public class TransactionDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = default!;
    public DateTime Date { get; set; }
    public string Category { get; set; } = default!;
} 