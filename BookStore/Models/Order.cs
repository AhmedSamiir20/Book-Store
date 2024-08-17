namespace BookStore.Models;

public class Order : BaseEntity
{
    public double OrderPrice { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public List<OrderBooks?>? OrderBooks { get; set; }

    public OrderStatus OrderStatus { get; set; } = OrderStatus.Open;
}