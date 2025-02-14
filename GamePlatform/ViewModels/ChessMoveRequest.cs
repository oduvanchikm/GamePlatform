namespace GamePlatform.ViewModels;

public class ChessMoveRequest
{
    public string From { get; set; }
    public string To { get; set; }
    public char PromotionPiece { get; set; } = ' ';
}