using System.Net.Http.Json;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public event Action ProductsChanged;

        public List<Product> Products { get; set; }

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetProductsAsync(string categoryUrl = null)
        {
            var res = string.IsNullOrWhiteSpace(categoryUrl) ?
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"/api/Product") :
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"/api/Product/category/{categoryUrl}");
            if (res != null && res.Success && res.Data != null)
                Products = res.Data;
            ProductsChanged.Invoke();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var res = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"/api/Product/{id}");
            if (res != null && res.Success && res.Data != null)
                return res.Data;
            return null;
        }
    }
}
