namespace BookStore.Models.DTOS;

public class BookDto
{
    public string Title { get; set; }
    public string Price { get; set; }
    public string Year { get; set; }
    public string Version { get; set; }
    public string AuthorName { get; set; }
    public int CategoryId { get; set; }
}
