namespace BookStore.Services;

public interface IBooksServices
{
    Task<IEnumerable<Book>> GetAll(int categoryid=0);
    Task<Book> GetById(int id);
    Task<Book> Add(Book book);
    Book Update(Book book);
    Book Delete(Book book);
}
