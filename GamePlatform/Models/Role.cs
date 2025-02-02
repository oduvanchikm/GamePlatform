namespace GamePlatform.Models;

public class Role
{
    public long RoleId { get; set; }
    public string NameRole { get; set; }
    public List<User> User { get; set; }
}