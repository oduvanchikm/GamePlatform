using Microsoft.AspNetCore.Mvc;
using GamePlatform.DAL;
using GamePlatform.Models;
using GamePlatform.Helpers;
using GamePlatform.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GamePlatform.Controllers;

[ApiController]
[Route("api/register-page")]
public class RegisterController(
    IDbContextFactory<ApplicationDbContext> _dbContextFactory,
    ILogger<RegisterController> _logger) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest registerRequest)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        
        _logger.LogInformation("[ RegisterController ] : Start registration method");
        _logger.LogInformation("[ RegisterController ] : Email " + registerRequest.Email + ", Password " + registerRequest.Password);
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (await context.User.AnyAsync(u => u.Email == registerRequest.Email))
        {
            _logger.LogInformation("[ RegisterController ] : Email is already taken");
            return BadRequest("Email is already taken");
        }
        
        string email = registerRequest.Email;
        string password = registerRequest.Password;
        string name = registerRequest.Name;
        string surname = registerRequest.Surname;
        string gender = registerRequest.Gender;
        string dateOfBirth = registerRequest.DateOfBirth;
        
        Console.WriteLine(name);
        Console.WriteLine(surname);
        Console.WriteLine(gender);
        Console.WriteLine(dateOfBirth);

        if (gender.Equals("null"))
        {
            _logger.LogInformation("[ RegisterController ] : null gender");
            return BadRequest("Please choose a gender");
        }
        
        var passwordHash = PasswordHelper.HashPassword(password);

        var role = await context.Role.FirstOrDefaultAsync(r => r.NameRole == "User");
        if (role == null)
        {
            _logger.LogInformation("[ RegisterController ] : Empty role");
            return BadRequest("Empty role");
        }
        
        var genderFromDb = await context.Gender.FirstOrDefaultAsync(g => g.NameGender == gender);
        if (genderFromDb == null)
        {
            _logger.LogInformation("[ RegisterController ] : Gender not found");
            return BadRequest("Gender not found");
        }

        var newUser = new User
        {
            Email = email,
            PasswordHash = passwordHash,
            RoleId = role.RoleId,
            UserName = name,
            UserSurname = surname,
            UserGenderId = genderFromDb.GenderId,
            DateOfBirth = DateTime.Parse(dateOfBirth).ToUniversalTime()
        };

        context.User.Add(newUser);
        await context.SaveChangesAsync();
        
        _logger.LogInformation("[ RegisterController ] : Registration Successful");
        return Ok("Registration Successful");
    }
}