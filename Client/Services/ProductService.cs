using System.Net.Http.Json;
using BlazorEcommerce.Shared;

using static System.Net.WebRequestMethods;

namespace BlazorEcommerce.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public event Action ProductsChanged;

        public List<Product> Products { get; set; }
        public List<Product> AdminProducts { get; set; }
        public string Message { get; set; } = "Loading producta...";
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public string LastSearchText { get; set; }

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

        public async Task SearchProducts(string search, int page)
        {
            LastSearchText = search;
            var res = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/search/{search}/{page}");
            if (res != null && res.Data != null)
            {
                Products = res.Data;
                //CurrentPage = result.Data.CurrentPage;
                //PageCount = result.Data.Pages;
            }
            if (Products.Count == 0) Message = "No products found.";
            ProductsChanged?.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _httpClient
                .GetFromJsonAsync<ServiceResponse<List<string>>>($"api/Product/searchsuggetions/{searchText}");
            return result.Data;
        }

        public Task GetAdminProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
