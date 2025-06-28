using System.ComponentModel.DataAnnotations;

namespace LifeSync.Application.Auth.DTOs;

public class LoginDto
{
    [Required(ErrorMessage = "Username là bắt buộc")]
    public string Username { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Password là bắt buộc")]
    public string Password { get; set; } = string.Empty;
} 