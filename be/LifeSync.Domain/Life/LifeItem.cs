using System.ComponentModel.DataAnnotations;
using LifeSync.Domain.Common.Enums;

namespace LifeSync.Domain.Life;

public class LifeItem
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;
    
    [StringLength(1000)]
    public string? Description { get; set; }
    
    public LifeItemType Type { get; set; } = LifeItemType.Todo;
    
    public LifeItemStatus Status { get; set; } = LifeItemStatus.Pending;
    
    public Priority Priority { get; set; } = Priority.Medium;
    
    public DateTime? DueDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
} 