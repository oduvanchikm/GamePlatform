using System.Collections.Generic;

namespace GamePlatform.Games.Tetris;

public class Tetris
{
    private readonly int Height = 20;
    private readonly int Width = 10;
    
    private Random random;
    private Tetromino newTetromino;
    public int[,] Grid;
    private Timer gameTimer;

    public Tetris()
    {
        Grid = new int[Width, Height];
        random = new Random();
        CreateNewTetromino();
        AddTetrominoToGrid();
        
        gameTimer = new Timer(AutoMoveDown, null, 3000, 3000);
    }
    
    private void AutoMoveDown(object state)
    {
        MoveDown();
    }

    private void CreateNewTetromino()
    {
        newTetromino = new Tetromino(random.Next(7));
    }
    
    private void AddTetrominoToGrid()
    {
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
    
    private void RemoveTetrominoFromGrid()
    {
        int[,] shape = newTetromino.Shape;
        for (int y = 0; y < shape.GetLength(0); y++)
        {
            for (int x = 0; x < shape.GetLength(1); x++)
            {
                int gridX = newTetromino.X + x;
                int gridY = newTetromino.Y + y;

                if (gridX >= 0 && gridX < Width && gridY >= 0 && gridY < Height)
                {
                    Grid[gridX, gridY] = 0;
                }
            }
        }
    }
    
    private bool CanMoveDown()
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

    private void MoveDown()
    {
        if (CanMoveDown())
        {
            RemoveTetrominoFromGrid();
            newTetromino.Y++;
            AddTetrominoToGrid();
        }
        else
        {
            CreateNewTetromino();
            AddTetrominoToGrid();
        }
    }
    
    public void RotateTetris()
    {
        RemoveTetrominoFromGrid();

        int[,] originalShape = (int[,])newTetromino.Shape.Clone();

        newTetromino.Rotate();

        if (!CanPlaceTetromino(newTetromino))
        {
            newTetromino.Shape = originalShape; 
        }

        AddTetrominoToGrid();
    }

    public void FastMoveDown()
    {
        while (CanMoveDown())
        {
            RemoveTetrominoFromGrid();
            newTetromino.Y++;
            AddTetrominoToGrid();
        }
    }

    
    private bool CanPlaceTetromino(Tetromino tetromino)
    {
        int[,] shape = tetromino.Shape;
        for (int y = 0; y < shape.GetLength(0); y++)
        {
            for (int x = 0; x < shape.GetLength(1); x++)
            {
                if (shape[y, x] == 1)
                {
                    int gridX = tetromino.X + x;
                    int gridY = tetromino.Y + y;

                    if (gridX < 0 || gridX >= Width || gridY < 0 || gridY >= Height)
                    {
                        return false;
                    }

                    if (Grid[gridX, gridY] == 1)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

}