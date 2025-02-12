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
    }
    
    public void Rotate()
    {
        int rows = Shape.GetLength(0);  // количество строк
        int cols = Shape.GetLength(1);  // количество столбцов

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols / 2; j++)
            {
                int temp = Shape[i, j];
                Shape[i, j] = Shape[i, cols - 1 - j];
                Shape[i, cols - 1 - j] = temp;
            }
        }
    }

}