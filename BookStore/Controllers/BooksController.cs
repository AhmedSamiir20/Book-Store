namespace BookStore.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBooksServices _booksServices;
    private readonly ICategoriesService _categoriesService;
    private readonly IMapper _mapper;

    public BooksController(IBooksServices booksServices, ICategoriesService categoriesService, IMapper mapper)
    {
        _booksServices = booksServices;
        _categoriesService = categoriesService;
        _mapper = mapper;
    }



    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    { 
        var books = await _booksServices.GetAll();
       var data= _mapper.Map<IEnumerable<BooksDetailsDto>>(books);  
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var book = await _booksServices.GetById(id);

        if (book == null)
            return BadRequest();
        var dto = _mapper.Map<BooksDetailsDto>(book);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] BookDto dto)
    {
        var ISValid = await _categoriesService.IsValidCategory(dto.CategoryId);
        if (!ISValid)
            return BadRequest();

        var book = new Book
        {
            CategoryId = dto.CategoryId,
            Price = dto.Price,
            Title = dto.Title,
            AuthorName = dto.AuthorName,
            Version = dto.Version,
            Year = dto.Year
        }; 

       _booksServices.Add(book);    
        return Ok(book);
    }

    [HttpGet("GetBooksByCategoryId")]
    public async Task<IActionResult> GetBooksByCategoryIdAsync(int categoryid)
    {
        var books = await _booksServices.GetAll(categoryid);
        var data= _mapper.Map<IEnumerable<BooksDetailsDto>>(books);
        return Ok(data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] BookDto dto)
    {
        var book = await _booksServices.GetById(id);    

        if (book == null)
            return BadRequest();

        var ISValid = await _categoriesService.IsValidCategory(dto.CategoryId);
        if (!ISValid)
            return BadRequest();



        book.CategoryId = dto.CategoryId;
        book.Price = dto.Price;
        book.Title = dto.Title;
        book.Version = dto.Version;
        book.AuthorName = dto.AuthorName;
        book.Year = dto.Year;


        _booksServices.Update(book);
        return Ok(book);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var book = await _booksServices.GetById(id);

        if (book == null)
            return NotFound();

       _booksServices.Delete(book); 

        return Ok(book);
    }
}
