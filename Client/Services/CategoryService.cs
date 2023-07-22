using System.Net.Http.Json;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public List<Category> Categories { get; set;} = new List<Category>();

    public async Task GetCategoriesAsync()
    {
        var res = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("/api/Category");
        if (res != null && res.Data != null)
            Categories = res.Data;
    }
}
