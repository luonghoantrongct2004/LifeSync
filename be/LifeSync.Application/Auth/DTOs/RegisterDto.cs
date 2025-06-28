using System.ComponentModel.DataAnnotations;

namespace LifeSync.Application.Auth.DTOs;

public class RegisterDto
{
    [Required(ErrorMessage = "Username là bắt buộc")]
    [StringLength(100, ErrorMessage = "Username không được vượt quá 100 ký tự")]
    public string Username { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email là bắt buộc")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Password là bắt buộc")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password phải có ít nhất 6 ký tự")]
    public string Password { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string? FirstName { get; set; }
    
    [StringLength(100)]
    public string? LastName { get; set; }
} 