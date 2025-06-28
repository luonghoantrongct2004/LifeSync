using System.ComponentModel.DataAnnotations;

namespace LifeSync.Application.Life.DTOs;

public class LifeItemDto
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Tiêu đề là bắt buộc")]
    [StringLength(200, ErrorMessage = "Tiêu đề không được vượt quá 200 ký tự")]
    public string Title { get; set; } = string.Empty;
    
    [StringLength(1000, ErrorMessage = "Mô tả không được vượt quá 1000 ký tự")]
    public string Description { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Loại là bắt buộc")]
    public string Type { get; set; } = "todo"; // "todo" or "goal"
    
    [Required(ErrorMessage = "Trạng thái là bắt buộc")]
    public string Status { get; set; } = "pending"; // "pending" or "completed"
    
    [Required(ErrorMessage = "Độ ưu tiên là bắt buộc")]
    public string Priority { get; set; } = "medium"; // "low", "medium", "high"
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
} 