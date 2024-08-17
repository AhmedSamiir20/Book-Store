namespace BookStore.Services;

public class CategoriesService : ICategoriesService
{
    private readonly ApplicationDbContext _context;

    public CategoriesService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category> Add(Category category)
    {
       
        _context.Categories.AddAsync(category);

        _context.SaveChanges();

        return category;
    }

    public Category Delete(Category category)
    {
        _context.Remove(category);
        _context.SaveChanges();
        return category;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories.OrderBy(c => c.Name).ToListAsync();
       
    }

    public async Task<Category> GetById(int id)
    {
       return await _context.Categories.FindAsync(id);
    }

    public async Task<bool> IsValidCategory(int id)
    {
        return await _context.Categories.AnyAsync(m => m.Id == id);
    }

    public  Category Update(Category category)
    {
        _context.Update(category);
        _context.SaveChanges();
        return category;
    }

    
}
