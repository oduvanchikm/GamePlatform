using System.Net;
using System.Security.Claims;
using GamePlatform.DAL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamePlatform.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GamePlatform.Controllers;

[ApiController]
[Authorize("UserPolicy")]
[Route("api/information-page")]
public class InformationController(
    IDbContextFactory<ApplicationDbContext> _dbContextFactory,
    ILogger<LoginController> _logger) : ControllerBase
{

    [HttpGet("logout")]
    public async Task<IActionResult> LogoutAsync()
    {
        _logger.LogInformation("[ Information Controller ] : Logout method");
        await HttpContext.SignOutAsync();
        return Ok(new { message = "Logout successful." });
    }

    private long FindUserById()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            return 0;
        }
        
        return long.Parse(userIdClaim.Value);
    }

    [HttpGet("information")]
    public async Task<IActionResult> InformationAsync()
    {
        _logger.LogInformation("[ Information Controller ] : Start information method");

        await using var context = _dbContextFactory.CreateDbContext();
        
        long userId = FindUserById();
        if (userId == 0)
        {
            return NotFound(new { message = "User not found." });
        }
        
        var user = await context.User
            .Include(x => x.Gender)
            .FirstOrDefaultAsync(x => x.UserId == userId);
        if (user == null)
        {
            _logger.LogInformation("[ Information Controller ] : User Not Found.");
            return BadRequest("User Not Found.");
        }
        
        _logger.LogInformation("[ Information Controller ] : Information person found. User: {user}", userId);

        InformationAboutPerson newPerson = new InformationAboutPerson
        {
            Name = user.UserName,
            Surname = user.UserSurname,
            DateOfBirth = user.DateOfBirth.ToString("dd/MM/yyyy"),
            Gender = user.Gender.NameGender,
            Email = user.Email
        };
        
        _logger.LogInformation("[ Information Controller ] : Send person information to client");
        
        return Ok(newPerson);
    }
}