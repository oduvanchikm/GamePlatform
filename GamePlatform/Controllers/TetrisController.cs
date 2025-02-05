using GamePlatform.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamePlatform.Games.Tetris;

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
}