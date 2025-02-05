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
    [HttpGet("start")]
    public IActionResult TetrisPage()
    {
        Tetris newGameTetris = new Tetris();
        var grid = ConvertToJaggedArray(newGameTetris.Grid);

        Console.WriteLine("TetrisController.MainPage()");
        _logger.LogInformation("[TetrisController] : Getting main page info");
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