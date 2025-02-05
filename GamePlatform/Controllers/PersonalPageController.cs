using GamePlatform.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamePlatform.Controllers;

[ApiController]
[Route("api/personal-page")]
public class PersonalPageController(
    ILogger<RegisterController> _logger) : ControllerBase
{
    [HttpGet]
    public IActionResult PersonalPage()
    {
        Console.WriteLine("PersonalPageController.MainPage()");
        _logger.LogInformation("[PersonalPageController] : Getting main page info");
        return Ok(new { message = "Welcome to Main Page Game Platform!" });
    }
}