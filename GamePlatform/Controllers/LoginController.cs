using System.Security.Claims;
using GamePlatform.DAL;
using GamePlatform.ViewModels;
using GamePlatform.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamePlatform.Controllers;

[ApiController]
[Route("api/login-page")]
public class LoginController(
    IDbContextFactory<ApplicationDbContext> _dbContextFactory,
    ILogger<LoginController> _logger) : ControllerBase
{
    public enum UserRole
    {
        Admin = 1,
        User = 2,
        Unauthenticated = 3
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        
        _logger.LogInformation("[ LoginController ] : Start registration method");
        _logger.LogInformation("[ LoginController ] : Email " + loginRequest.Email + ", Password " + loginRequest.Password);
    
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
    
        if (await context.User.AnyAsync(u => u.Email != loginRequest.Email && u.PasswordHash != PasswordHelper.HashPassword(loginRequest.Password)))
        {
            _logger.LogInformation("[ LoginController ] : Not logged in");
            return Unauthorized();
        }
        
        var user = await context.User.Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == loginRequest.Email);
        if (user == null)
        {
            _logger.LogWarning("[ LoginController ] : Authentication failed: User with email {Email} not found.", loginRequest.Email);
            return Unauthorized();
        }

        bool isPasswordValid;
        
        isPasswordValid = user.PasswordHash != PasswordHelper.HashPassword(loginRequest.Password) ? false : true;

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
        
        var userRole = (UserRole)user.RoleId;
        
        string redirectTo = userRole == UserRole.Admin ? "/admin" : "/";
        return Ok(new { message = "Login Successful", redirectTo, fullName = $"{user.UserName} {user.UserSurname}" });
    }
}