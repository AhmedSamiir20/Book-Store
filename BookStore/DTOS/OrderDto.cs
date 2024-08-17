namespace BookStore.DTOS;

public class OrderDto
{
    public double OrderPrice { get; set; }
    public int UserId { get; set; }
    public List<OrderBooks?>? OrderBooks { get; set; }
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Open;
}
