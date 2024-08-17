
namespace BookStore.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class RegistrationsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RegistrationsController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUpAsync([FromForm] RegistrationDto dto)
    {

        if (await _context.registrations.AnyAsync(r => r.Email == dto.Email))//check about new or old register
            return NotFound("Email is Already Registered ");
        
        var register = new Registration
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            City = dto.City,
            Email = dto.Email,
            Password = dto.Password,
            ConfirmPassword = dto.ConfirmPassword,
        };
        
        _context.AddAsync(register);
        _context.SaveChanges();
        return Ok(register);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _context.registrations.ToListAsync());
    }
    [HttpPost("LogIn")]
    public async Task<IActionResult> LogInAsync([FromForm] Login log)
    {
        var user = await _context.registrations.Where(r => r.Email == log.Email).SingleOrDefaultAsync(r => r.Password == log.Password);
        if (user == null)
            return NotFound("The email Or Password you entered is not associated with an account ");

        //var checkpass = await _context.registrations.Where(u=>u.Email==log.Email).SingleOrDefaultAsync(r => r.Password == log.Password);
        //if (checkpass == null)
        //    return BadRequest("Password is wrong ,Please try Agin");

        return Ok("Login Succeed"); 
        
    }

}
