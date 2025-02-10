using System.Security.Claims;
using GamePlatform.DAL;
using GamePlatform.ViewModels;
using GamePlatform.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamePlatform.Controllers;

[ApiController]
[Route("api/login-page")]
public class LoginController(
    IDbContextFactory<ApplicationDbContext> _dbContextFactory,
    ILogger<LoginController> _logger) : ControllerBase
{
    private enum UserRole
    {
        Admin = 1,
        User = 2
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        
        _logger.LogInformation("[ LoginController ] : Start login method");
        _logger.LogInformation("[ LoginController ] : Email " + loginRequest.Email + ", Password " + loginRequest.Password);
    
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var user = await context.User.Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == loginRequest.Email);

        if (user == null || user.PasswordHash != PasswordHelper.HashPassword(loginRequest.Password))
        {
            _logger.LogWarning("[ LoginController ] : Authentication failed: Invalid email or password.");
            return Unauthorized();
        }
        
        bool isPasswordValid = user.PasswordHash == PasswordHelper.HashPassword(loginRequest.Password);

        if (!isPasswordValid)
        {
            _logger.LogWarning("[ LoginController ] : Authentication failed: Invalid password.");
            return Unauthorized();
        }
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role.NameRole)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true,
            AllowRefresh = true
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties
        );
        
        var userRole = user.Role.NameRole == "Admin" ? UserRole.Admin : UserRole.User;
        
        string redirectTo = userRole == UserRole.Admin ? "/admin" : "/personal";
        
        _logger.LogInformation("[ LoginController ] : User logged in");
        
        return Ok(new { message = "Login Successful", redirectTo, fullName = $"{user.UserName} {user.UserSurname}" });
    }
}