namespace BlazorEcommerce.Server;

public interface ICategoryService
{
    Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
}
