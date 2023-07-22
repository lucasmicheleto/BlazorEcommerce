using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BlazorEcommerce.Server;

[Route("api/[controller]")]
[ApiController]
public class CategoryController: ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories()
    {
        var c = await _categoryService.GetCategoriesAsync();
        return Ok(c);
    }
}
