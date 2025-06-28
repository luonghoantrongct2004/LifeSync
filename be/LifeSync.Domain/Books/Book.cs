using System.ComponentModel.DataAnnotations;
using LifeSync.Domain.Common.Enums;

namespace LifeSync.Domain.Books;

public class Book
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    [StringLength(100)]
    public string Author { get; set; } = string.Empty;
    
    [StringLength(1000)]
    public string? Description { get; set; }
    
    public Language Language { get; set; } = Language.Vietnamese;
    
    public BookStatus Status { get; set; } = BookStatus.Available;
    
    [StringLength(500)]
    public string? PdfUrl { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
} 