using GamePlatform.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamePlatform.Controllers;

public class InformationController(
    IDbContextFactory<ApplicationDbContext> _dbContextFactory,
    ILogger<LoginController> _logger) : ControllerBase
{
    
}