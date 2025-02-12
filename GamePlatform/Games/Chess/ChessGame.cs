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

    public bool MakeMove(string from, string to)
    {
        Move move = new Move(from, to, game.WhoseTurn);
        return (game.MakeMove(move, true) == MoveType.Move);
    }
}