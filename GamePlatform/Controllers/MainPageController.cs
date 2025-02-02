using GamePlatform.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamePlatform.Controllers;

[ApiController]
[Route("api/main-page")]
public class MainPageController(IDbContextFactory<ApplicationDbContext> _dbContextFactory, 
    ILogger<MainPageController> _logger) : ControllerBase
{
    [HttpGet]
    public IActionResult GetMainPageInfo()
    {
        var mainPageInfo = new
        {
            Message = "Welcome to Main Page Game Platform!",
        };

        return Ok(mainPageInfo);
    }
}