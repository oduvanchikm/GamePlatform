using GamePlatform.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamePlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MainPageController(ILogger<MainPageController> _logger) : ControllerBase
{
    [HttpGet]
    public IActionResult GetMainPageInfo()
    {
        _logger.LogInformation("[MainPageController] : Getting main page info");
        return Ok("Welcome to Main Page Game Platform!");
    }
}