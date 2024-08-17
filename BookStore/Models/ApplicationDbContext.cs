namespace BookStore.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	public DbSet<Book> Books { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Registration> registrations { get; set; }
}