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
        
        Grid[4, 0] = 1;
        Grid[4, 1] = 1;
        Grid[5, 1] = 1;
        Grid[5, 2] = 1;

    }

    private void CreateNewTetromino()
    {
        newTetromino = new Tetromino(random.Next(7));
    }
}