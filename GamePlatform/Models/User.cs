namespace GamePlatform.Models;

public class User
{
    public long UserId { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public Gender Gender { get; set; }
    public long UserGenderId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
    public Role Role { get; set; }
    public long RoleId { get; set; }
    
    public IEnumerable<GameUsers> GameUsers { get; set; }
}