namespace GamePlatform.Models;

public class Gender
{
    public long GenderId { get; set; }
    public string NameGender { get; set; }
    public List<User> User { get; set; }
}