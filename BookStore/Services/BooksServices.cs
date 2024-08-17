namespace BookStore.Services;

public class BooksServices : IBooksServices
{
    private readonly ApplicationDbContext _context;

    public BooksServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Book> Add(Book book)
    {
        await _context.Books.AddAsync(book);
        _context.SaveChanges();
        return book;
    }

    public Book Delete(Book book)
    {
        _context.Remove(book);
        _context.SaveChanges();
        return book;
    }

    public async Task<IEnumerable<Book>> GetAll(int categoryid = 0)
    {
        return await _context.Books
            .Where(m => m.CategoryId == categoryid || categoryid == 0)
            .OrderByDescending(m => m.Price)
            .Include(m => m.Category)
            .ToListAsync();
    }

    public async Task<Book> GetById(int id)
    {
        return await _context.Books.Include(m => m.Category).SingleOrDefaultAsync(b => b.Id == id);
    }

    public Book Update(Book book)
    {
        _context.Update(book);
        _context.SaveChanges();
        return book;
    }
}
