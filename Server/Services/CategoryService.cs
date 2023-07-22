using BlazorEcommerce.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server;

public class CategoryService : ICategoryService
{
    private readonly BlCommerceDataContext _context;

    public CategoryService(BlCommerceDataContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return new ServiceResponse<List<Category>>()
        {
            Data = categories,
            Success = true
        };
    }
}
