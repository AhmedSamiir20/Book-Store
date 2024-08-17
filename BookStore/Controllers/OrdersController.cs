
namespace BookStore.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OrdersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync() =>
                     Ok(await _context.Orders.Include(e => e.OrderBooks).ThenInclude(e=>e.Book).ToListAsync());

    [HttpGet("{GetById}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        Order order = await _context.Orders.Include(e => e.OrderBooks).ThenInclude(e => e.Book).FirstOrDefaultAsync(e => e.Id == id);

        if (order is null)
            return NotFound("There is no orders by this id");

        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] Order? o)
    {
        var order = new Order
        {
            OrderPrice = o.OrderPrice,
            UserId = o.UserId,
            OrderBooks = o.OrderBooks,
        };

        await _context.Orders.AddAsync(order);
        _context.SaveChanges();
        return Ok(order);
    }

    [HttpGet("GetOrdersByCustomerId")]
    public async Task<IActionResult> GetOrdersByCustomerIdAsync(int UserId) =>
                      Ok(await _context.Orders.Where(m => m.UserId == UserId).OrderByDescending(x => x.OrderPrice).Include(m => m.User).Include(e => e.OrderBooks).ThenInclude(e => e.Book).ToListAsync());

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, Order dto)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order is null)
            return BadRequest();

        var ISValid = await _context.Users.AnyAsync(m => m.Id == dto.UserId);
        if (!ISValid)
            return BadRequest();

        order.OrderBooks = dto.OrderBooks;
        order.UserId = dto.UserId;
        order.OrderPrice = dto.OrderPrice;
        _context.Orders.Update(order);

        _context.SaveChanges();
        return Ok(order);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order is null)
            return NotFound("There is no orders by this id");

        _context.Remove(order);
        _context.SaveChanges();

        return Ok(order);
    }
}
