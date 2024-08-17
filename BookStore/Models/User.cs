namespace BookStore.Models;

public class User:BaseEntity
{
    public int Age { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}
