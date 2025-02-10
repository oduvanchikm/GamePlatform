using System.Security.Claims;
using GamePlatform.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamePlatform.Games.Tetris;
using GamePlatform.Models;

namespace GamePlatform.Controllers;

[ApiController]
[Route("api/tetris-page")]
public class TetrisController(
    IDbContextFactory<ApplicationDbContext> _dbContextFactory,
    ILogger<TetrisController> _logger) : ControllerBase
{
    private Tetris newGameTetris = new Tetris();
    
    [HttpGet("start")]
    public IActionResult TetrisPage()
    {
        var grid = ConvertToJaggedArray(newGameTetris.Grid);

        Console.WriteLine("TetrisController.MainPage()");
        _logger.LogInformation("[TetrisController] : Getting main page info");
        return Ok(new { grid });
    }
    
    [HttpPost("rotate")]
    public IActionResult RotateTetromino()
    {
        _logger.LogInformation("[TetrisController] : Getting Rotate");
        newGameTetris.RotateTetris();
        var grid = ConvertToJaggedArray(newGameTetris.Grid);
        
        _logger.LogInformation("[TetrisController] : end Rotate");
        return Ok(new { grid });
    }
    
    [HttpPost("down")]
    public IActionResult DownTetromino()
    {
        _logger.LogInformation("[TetrisController] : Getting down");
        newGameTetris.MoveDown();
        var grid = ConvertToJaggedArray(newGameTetris.Grid);
        
        _logger.LogInformation("[TetrisController] : end down");
        return Ok(new { grid });
    }

    private int[][] ConvertToJaggedArray(int[,] array)
    {
        int rows = array.GetLength(1);
        int cols = array.GetLength(0);
        return Enumerable.Range(0, rows)
            .Select(y => Enumerable.Range(0, cols)
                .Select(x => array[x, y])
                .ToArray())
            .ToArray();
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
    public async Task<IActionResult> AddResultGamesAsync()
    {
        long userId = FindUserById();
        int flag = 0;
        if (userId == 0)
        {
            flag = 1;
            _logger.LogInformation("[TetrisController] : Unauthorized user plays the tetris");
        }

        await using var context = _dbContextFactory.CreateDbContext();

        var user = await context.User
            .FirstOrDefaultAsync(u => u.UserId == userId);
        if (user == null)
        {
            return NotFound(new { message = "User not found." });
        }
        
        var game = await context.Game
            .FirstOrDefaultAsync(g => g.GameName == "Tetris");
        if (game == null)
        {
            return NotFound(new { message = "Game not found." });
        }

        GameUsers gameUsers = new GameUsers()
        {
            GameId = game.GameId,
            UserId = user.UserId,
            StartTime = DateTime.Now
        };
        
        return Ok(new { message = "Game added.", gameUsers });
    }
}