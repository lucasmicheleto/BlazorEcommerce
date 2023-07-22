using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        event Action ProductsChanged;
        Task GetProductsAsync(string categoryUrl = null);
        Task<Product> GetProductAsync(int id);
    }
}