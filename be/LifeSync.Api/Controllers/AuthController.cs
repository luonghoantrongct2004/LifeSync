using LifeSync.Application.Auth.DTOs;
using LifeSync.Application.Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace LifeSync.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Đăng nhập vào hệ thống
    /// </summary>
    /// <param name="loginDto">Thông tin đăng nhập</param>
    /// <returns>Token JWT nếu đăng nhập thành công</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await _authService.LoginAsync(loginDto);
        if (result == null)
        {
            return Unauthorized(new { message = "Username hoặc password không đúng" });
        }

        return Ok(result);
    }

    /// <summary>
    /// Đăng ký tài khoản mới
    /// </summary>
    /// <param name="registerDto">Thông tin đăng ký</param>
    /// <returns>Token JWT nếu đăng ký thành công</returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var result = await _authService.RegisterAsync(registerDto);
        if (result == null)
        {
            return BadRequest(new { message = "Username hoặc email đã tồn tại" });
        }

        return CreatedAtAction(nameof(Login), result);
    }
} 