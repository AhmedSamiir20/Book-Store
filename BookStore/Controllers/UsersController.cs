namespace BookStore.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public UsersController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync() => Ok(await _context.Users.ToListAsync());

    [HttpGet("{GetById}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return NotFound("There is User By This Id (^^) ");

        return Ok(user);

    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] UserDto c)
    {
        var user = new User
        {
            Name = c.Name,
            Address = c.Address,
            Email = c.Email,
            Age = c.Age
        };
        _context.Users.AddAsync(user);
        _context.SaveChanges();
        return Ok(user);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] UserDto dto)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return NotFound("There is Customer By This Id (^^) ");

        user.Email = dto.Email;
        user.Address = dto.Address;
        user.Name = dto.Name;
        user.Age = dto.Age;

        _context.SaveChanges();

        return Ok(user);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return NotFound("There is User By This Id (^^) ");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return Ok(user);
    }
}
