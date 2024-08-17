namespace BookStore.Models;

public class Book : BaseEntity
{
    public string Year { get; set; }
    public string Title { get; set; }
    public string Price { get; set; }
    public string Version { get; set; }
    public string AuthorName { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
