
namespace BookStore.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesService _categoriesService;

    

    public CategoriesController(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var category = await _categoriesService.GetAll();

        return Ok(category);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryDto g)
    {
        var category = new Category { Name = g.Name };

        await _categoriesService.Add(category);

        return Ok(category);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] CategoryDto dto)
    {
        var category = await _categoriesService.GetById(id);

        if (category == null)
            return NotFound();
        category.Name = dto.Name;

       _categoriesService.Update(category);
        return Ok(category);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var category = await _categoriesService.GetById(id);

        if (category == null)
            return NotFound($"No Category was found with ID :{id}");

        _categoriesService.Delete(category);
        return Ok(category);
    }
}