using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client;

public interface ICategoryService
{
    List<Category> Categories { get; set; }
    Task GetCategoriesAsync();
}
