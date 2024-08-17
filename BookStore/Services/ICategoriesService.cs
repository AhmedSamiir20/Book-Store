namespace BookStore.Services;

public interface ICategoriesService
{
    Task<IEnumerable<Category>> GetAll();
    Task<Category> GetById(int id);
    Task<Category> Add(Category category);
    Category Update(Category category);
    Category Delete(Category category);
    Task<bool> IsValidCategory(int id);

}
