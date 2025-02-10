namespace GamePlatform.Models;

public class Game
{
    public long GameId { get; set; }
    public string GameName { get; set; }
    public string GameDescription { get; set; }
    
    public IEnumerable<GameUsers> GameUsers { get; set; }
}