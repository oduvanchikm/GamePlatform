using System.Collections.Generic;

namespace GamePlatform.Games.Tetris;

public class Tetris
{
    private readonly int Height = 20;
    private readonly int Width = 10;
    
    private Random random;
    private Tetromino newTetromino;
    public int[,] Grid;

    public Tetris()
    {
        Grid = new int[Width, Height];
        random = new Random();
        CreateNewTetromino();
        AddTetrominoToGrid();
    }

    private void CreateNewTetromino()
    {
        newTetromino = new Tetromino(random.Next(7));
    }
    
    private void AddTetrominoToGrid()
    {
        //Grid = new int[Width, Height];
    
        int[,] shape = newTetromino.Shape;
        for (int y = 0; y < shape.GetLength(0); y++)
        {
            for (int x = 0; x < shape.GetLength(1); x++)
            {
                if (shape[y, x] == 1)
                {
                    int gridX = newTetromino.X + x;
                    int gridY = newTetromino.Y + y;

                    if (gridX >= 0 && gridX < Width && gridY >= 0 && gridY < Height)
                    {
                        Grid[gridX, gridY] = 1;
                    }
                }
            }
        }
    }
    
    public bool CanMoveDown()
    {
        int[,] shape = newTetromino.Shape;
    
        for (int y = 0; y < shape.GetLength(0); y++)
        {
            for (int x = 0; x < shape.GetLength(1); x++)
            {
                if (shape[y, x] == 1)
                {
                    int gridX = newTetromino.X + x;
                    int gridY = newTetromino.Y + y + 1;

                    if (gridY >= Height || Grid[gridX, gridY] == 1)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public void MoveDown()
    {
        if (CanMoveDown())
        {
            Console.WriteLine("gygyo");
            newTetromino.Y++;
            AddTetrominoToGrid();
        }
        else
        {
            Console.WriteLine("hhhh");
            CreateNewTetromino();
            AddTetrominoToGrid();
        }
    }
    
    public void RotateTetris()
    {
        newTetromino.Rotate();
        Console.WriteLine($"information about tetromino in rotation in tetris: {newTetromino.Shape.GetLength(0)}x{newTetromino.Shape.GetLength(1)}");
        AddTetrominoToGrid();
        Console.WriteLine($"information 2 about tetromino in rotation in tetris: {newTetromino.Shape.GetLength(0)}x{newTetromino.Shape.GetLength(1)}");

    }
}