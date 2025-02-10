namespace GamePlatform.Games.Tetris;

// 7 стандартных тетромино: 
// 0 - прямая форма
// 1 - J
// 2 - L
// 3 - 0 (квадрат)
// 4 - S
// 5 - T
// 6 - Z

public class Tetromino
{
    public int[,] Shape { get; set; }
    
    public int X { get; set; }
    public int Y { get; set; }

    // private ILogger<Tetromino> _logger;

    public Tetromino(int type)
    {
        X = 3;
        Y = 4;
        
        switch (type)
        {
            case 0:
                Shape = new int[,]
                {
                    { 1, 1, 1, 1 }
                };
                break;
            
            case 1:
                Shape = new int[,]
                {
                    { 1, 0, 0 },
                    { 1, 1, 1 }
                };
                break;
            
            case 2:
                Shape = new int[,]
                {
                    { 0, 0, 1 },
                    { 1, 1, 1 }
                };
                break;
            
            case 3:
                Shape = new int[,]
                {
                    { 1, 1 },
                    { 1, 1 }
                };
                break;
            
            case 4:
                Shape = new int[,]
                {
                    { 0, 1, 1 },
                    { 1, 1, 0 }
                };
                break;
            
            case 5:
                Shape = new int[,]
                {
                    { 0, 1, 0 },
                    { 1, 1, 1 }
                };
                break;
            
            case 6:
                Shape = new int[,]
                {
                    { 1, 1, 0 },
                    { 0, 1, 1 }
                };
                break;
            
            default:
                Shape = new int[,]
                {
                    { 1, 1, 1, 1 }
                };
                break;
        }
        
        Console.WriteLine($"Tetromino in constructor {Shape.GetLength(0)}, {Shape.GetLength(1)}");
    }

    public void Rotate()
    {
        int x = Shape.GetLength(0); // это ширина тетромино
        int y = Shape.GetLength(1); // это длина тетромино 
        
        Console.WriteLine($"Tetromino in rotate method {x}, {y}");
        
        int[,] rotatedShape = new int[y, x];

        for (int i = 0; i < x; ++i)
        {
            for (int j = 0; j < y; ++j)
            {
                rotatedShape[j, x - i - 1] = Shape[i, j];
            }
        }
        
        Shape = rotatedShape;
    }
}