using System.Collections.Generic;

namespace GamePlatform.Games.Tetris;

public class Tetris
{
    private readonly int Height = 20;
    private readonly int Width = 10;
    
    private Random random;
    public Tetromino newTetromino;
    public int[,] Grid;

    public Tetris()
    {
        Grid = new int[Width, Height];
        random = new Random();
        CreateNewTetromino();
        
        Grid[4, 6] = 1;
        Grid[4, 7] = 1;
        Grid[5, 7] = 1;
        Grid[5, 8] = 1;
    }

    private void CreateNewTetromino()
    {
        newTetromino = new Tetromino(random.Next(7));
    }
    
    public void RotateTetris() => newTetromino.Rotate();
}