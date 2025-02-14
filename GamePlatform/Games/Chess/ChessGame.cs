using ChessDotNet;

namespace GamePlatform.Games.Chess;

public class ChessGameWrapper
{
    private ChessGame game;

    public ChessGameWrapper()
    {
        game = new ChessGame();
    }

    public string getFEN()
    {
        return game.GetFen();
    }

    public bool MakeMove(string from, string to, char promotionPiece = ' ')
    {
        Move move = new Move(from, to, game.WhoseTurn, promotionPiece);
        MoveType moveResult = game.MakeMove(move, true);
        
        Console.WriteLine(moveResult);

        return (moveResult & MoveType.Move) != 0 || 
               (moveResult & MoveType.Capture) != 0 || 
               (moveResult & MoveType.EnPassant) != 0 || 
               (moveResult & MoveType.Castling) != 0;
    }

}