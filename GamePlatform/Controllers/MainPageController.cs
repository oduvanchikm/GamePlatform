using GamePlatform.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamePlatform.Controllers;

[ApiController]
[Route("api/main-page")]
public class MainPageController(ILogger<MainPageController> _logger) : ControllerBase
{
    [HttpGet]
    public IActionResult MainPage()
    {
        Console.WriteLine("MainPageController.MainPage()");
        _logger.LogInformation("[MainPageController] : Getting main page info");
        return Ok(new { message = "Welcome to Main Page Game Platform!" });
    }
}