using GamePlatform.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamePlatform.Games.Chess;
using GamePlatform.ViewModels;

namespace GamePlatform.Controllers;

[ApiController]
[Route("api/chess-page")]
public class ChessController(
    IDbContextFactory<ApplicationDbContext> _dbContextFactory,
    ILogger<ChessController> _logger) : ControllerBase
{
    private static ChessGameWrapper _chessGame = new ChessGameWrapper();
    
    [HttpGet("state")]
    public IActionResult GetChessState()
    {
        _logger.LogInformation("[ChessController] : Getting GetChessState page info");
        return Ok(new { fen = _chessGame.getFEN() });
    }

    [HttpPost("move")]
    public IActionResult MakeMove([FromBody] ChessMoveRequest request)
    {
        _logger.LogInformation("[ChessController] : start making move method");
        bool isValid = _chessGame.MakeMove(request.From, request.To, request.PromotionPiece);

        if (!isValid)
        {
            _logger.LogInformation("[ChessController] : bad request in make move");
            return BadRequest();
        }
        
        _logger.LogInformation("[ChessController] : request making move success");
        
        return Ok(new { fen = _chessGame.getFEN() });
    }
}