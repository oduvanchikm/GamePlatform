namespace GamePlatform.Models;

public class User
{
    public long UserId { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
    public Role Role { get; set; }
    public long RoleId { get; set; }
}