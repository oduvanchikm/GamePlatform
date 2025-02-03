using Microsoft.AspNetCore.Mvc;
using GamePlatform.DAL;
using GamePlatform.Models;
using GamePlatform.Helpers;
using GamePlatform.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GamePlatform.Controllers;

[ApiController]
[Route("api/register-page")]
public class RegisterController(
    IDbContextFactory<ApplicationDbContext> _dbContextFactory,
    ILogger<RegisterController> _logger) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        Console.WriteLine("rfrifh8rf");
        await using var context = _dbContextFactory.CreateDbContext();
        
        _logger.LogInformation("[ RegisterController ] : Start registration method");
        _logger.LogInformation("[ RegisterController ] : Email " + registerRequest.Email + ", Password " + registerRequest.Password);

        if (await context.User.AnyAsync(u => u.Email == registerRequest.Email))
        {
            _logger.LogInformation("[ RegisterController ] : Email is already taken");
            return BadRequest("Email is already taken");
        }
        
        var passwordHash = PasswordHelper.HashPassword(registerRequest.Password);

        string my = "20012005";
        var new_my = PasswordHelper.HashPassword(my);
        _logger.LogInformation("[ My ] : " + new_my);

        var role = await context.Role.FirstOrDefaultAsync(r => r.NameRole == "User");
        if (role == null)
        {
            _logger.LogInformation("[ RegisterController ] : Empty role");
            return BadRequest("Empty role");
        }

        var newUser = new User
        {
            Email = registerRequest.Email,
            PasswordHash = passwordHash,
            RoleId = role.RoleId
        };

        context.User.Add(newUser);
        await context.SaveChangesAsync();
        
        _logger.LogInformation("[ RegisterController ] : Registration Successful");
        return Ok("Registration Successful");
    }
}