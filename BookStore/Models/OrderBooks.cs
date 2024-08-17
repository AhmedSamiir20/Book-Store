namespace BookStore;

public class OrderBooks : BaseEntity
{
    public int OrderId { get; set; }
    public int BookId { get; set; }
    public Book? Book { get; set; }
}
